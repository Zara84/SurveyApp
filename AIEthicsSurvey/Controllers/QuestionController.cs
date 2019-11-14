using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIEthicsSurvey.Models;

namespace AIEthicsSurvey.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        public ActionResult DisplayQuestion()
        {
            var question = new Question() { ID = 0, questionText = "some question text", answerType = AnswerType.Binary };
            return View();
        }

        public ActionResult Random()
        {
            var question = new Question() { ID = 0, questionText = "some question text", answerType = AnswerType.Binary };
            return View(question);
        }
    }
}