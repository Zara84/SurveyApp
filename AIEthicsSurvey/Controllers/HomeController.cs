using DataLibrary.Business_Logic;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIEthicsSurvey.Controllers
{
    public class HomeController : Controller, IController
    {
        List<Category> data = new List<Category>();
        List<Models.Category> cats = new List<Models.Category>();
        string ranks;

        public string currentUser;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult StartNewSurvey()
        {
            data = CategoryProcessor.CategoryLoader();
            
            foreach(Category c in data)
            {
                cats.Add(new Models.Category { Id = c.Id, Name = c.Name });
            }
           //ViewBag.Message("Sort these to begin");
            return PartialView(cats);
        }

        public ActionResult Testingget(string name)
        {
            this.ranks = name;
            string trimmedRanks = name.Replace(" ", "");

            string[] ranks = trimmedRanks.Split(',');
            data = CategoryProcessor.CategoryLoader();

            for (int i = 0; i< data.Count; i++)
            {
                Models.Category c = new Models.Category();

                c.Id = data[i].Id;
                
                c.Name = data[i].Name;
                c.rank = Array.IndexOf(ranks, data[i].Id.ToString());

                c.subcats = CategoryProcessor.SubCategoriesOf(data[i].Id);

                cats.Add(c);
            }

            List<Models.Category> rankedCats = cats.OrderBy(x => x.rank).ToList();
            Session["cats"] = rankedCats;
            TempData["ranks"] = name;// this.ranks;

            string userID = generateUserID();
            Session["userID"] = userID;

            return PartialView();
    }

        public string generateUserID()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");

            return GuidString;
        }
        

        public ActionResult IDreminder(int i)
        {
            return PartialView(new Models.User { ID = (string)Session["userID"] });
        }

        public ActionResult reminderModal()
        {
            return PartialView(new Models.User { ID = (string)Session["userID"] });
        }
    }
}