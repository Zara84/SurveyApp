using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIEthicsSurvey.Models;
using DataLibrary.Business_Logic;

namespace AIEthicsSurvey.Controllers
{
    public class QuestionController : Controller
    {
        List<DataLibrary.Models.Category> data = new List<DataLibrary.Models.Category>();
        List<Models.Category> cats = new List<Models.Category>();
        string ranks;
        public List<Models.Category> categories = new List<Models.Category>();
        public List<Models.Question> questions = new List<Models.Question>();
        public List<DataLibrary.Models.Question> rawQuestions = new List<DataLibrary.Models.Question>();

        // GET: Question

        public ActionResult SurveyContainer()
        {
            return View((List<Models.Category>)Session["rankedCats"]);
        }

        public string CurrentCategory(string cat_id)
        {
            Session["currentCat"] = Int32.Parse(cat_id.Split('_')[1].Trim());
            return cat_id;
        }

        
        public ActionResult DisplayParentQuestions(string cat_id)
        {
            int id;
            if (cat_id !=null)
                Session["currentCat"] = Int32.Parse(cat_id.Split('_')[1].Trim());

            if (Session["currentCat"] != null)
                id = (int)Session["currentCat"];
            else
                id = 0;

            return /*((List<Models.Question>)Session["questions"])
                .Where(x => x.categoryID == id.ToString() && x.parentID == null)
                .ToList().Count;*/
                PartialView(((List<Models.Question>)Session["questions"])
                .Where(x => x.categoryID==id.ToString() && x.parentID==null)
                .ToList());
        }
        
        public ActionResult CategoryNav()
        {
            return PartialView(((List<Models.Category>)Session["rankedCats"]));
        }

        public ActionResult SubcatNav(string cat_id)
        {
            int id;
            if (cat_id != null)
                Session["currentCat"] = Int32.Parse(cat_id)-1;

            if (Session["currentCat"] != null)
                id = (int)Session["currentCat"];
            else
                id = 0;

            return PartialView(((List<Models.Category>)Session["cats"])[id].subcats);
        }

        public ActionResult QChildren(int id)
        {
            List<Models.Question> parent = ((List<Models.Question>)Session["questions"])
                                                     .Where(x => x.ID == id).ToList();

            return PartialView(parent[0].children);
        }

        public string SetCurrentQuestion(string data)
        {
            Session["currentCat"] = Int32.Parse(data.Trim());

            return data;
        }

        public string generateUserID()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");

            return GuidString;
        }

        public string parseCats(string name)
        {
            this.ranks = name;
            string trimmedRanks = name.Replace(" ", "");

            string[] ranks = trimmedRanks.Split(',');

            data = CategoryProcessor.CategoryLoader();

            for (int i = 0; i < data.Count; i++)
            {
                Models.Category c = new Models.Category();

                c.Id = data[i].Id;

                c.Name = data[i].Name;
                c.rank = Array.IndexOf(ranks, data[i].Id.ToString());

                c.subcats = CategoryProcessor.SubCategoriesOf(data[i].Id);

                cats.Add(c);
            }

            List<Models.Category> rankedCats = cats.OrderBy(x => x.rank).ToList();
            Session["cats"] = cats;
            Session["rankedCats"] = rankedCats;
            //TempData["ranks"] = name;// this.ranks;

            string userID = generateUserID();
            Session["userID"] = userID;

            return name;
        }

        public string parseQuestions()
        {
            if (Session["answers"] == null)
            {
                List<string> answers = new List<string>();
                for (int i = 0; i < 200; i++)
                {
                    answers.Add("");
                }
                Session["answers"] = answers;
            }

            Session["questions"] = new List<Models.Question>();

            while (((List<Models.Question>)Session["questions"]).Count <= 0)
            {
                rawQuestions = QuestionProcessor.LoadQuestions();

                for (int i = 0; i < rawQuestions.Count; i++)
                {
                    Models.Question q = new Models.Question();

                    q.ID = rawQuestions[i].Id;

                    if (rawQuestions[i].parentID != null)
                        q.parentID = rawQuestions[i].parentID.ToString();
                    else
                        q.parentID = null;

                    q.questionText = rawQuestions[i].questionText;
                    q.categoryID = rawQuestions[i].categoryId.ToString();
                    q.subcategoryID = rawQuestions[i].ToString();

                    QuestionProcessor.LoadChildrenOf(rawQuestions[i].Id)
                        .ForEach(x => q.children.Add(Helpers.Utils.DataToModelQuestion(x)));

                    questions.Add(q);
                }

                Session["questions"] = questions;
            }
            return questions.Count.ToString();
        }

        public ActionResult BinaryAnswer(AIEthicsSurvey.Models.Question q)
        {
            //ViewBag["id"] = id;
            return PartialView(q);
        }

        public int RegisterAnswer(string a, string id)
        {
            if (Session["answers"]==null)
            {
                List<string> answers = new List<string>();
                for(int i=0; i<200; i++)
                {
                    answers.Add("");
                }
                Session["answers"] = answers;
            }
            int index = Int32.Parse(id);

            

            

            if(((List<string>)Session["answers"])[index].Contains("yes"))
                if((a=="")||(a.Contains("no")))
                {
                   // ((List<string>)Session["answers"])[index] = a;

                    ((List<Models.Question>)Session["questions"])
                                                     .Where(x => x.parentID == id).ToList()
                                                     .ForEach(x => {
                                                         ((List<string>)Session["answers"])[x.ID] = "";
                                                     });
                }

         /*   if (((List<string>)Session["answers"])[index] == "")
            {
                ((List<string>)Session["answers"])[index] = a;
            }*/
            ((List<string>)Session["answers"])[index] = a;
            return index;
        }

    }


}