using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIEthicsSurvey.Helpers
{
    public static class Utils
    {
        public static AIEthicsSurvey.Models.Question DataToModelQuestion(DataLibrary.Models.Question data)
        {
            AIEthicsSurvey.Models.Question q = new Models.Question();

            q.ID = data.Id;
            q.categoryID = data.categoryId.ToString();
            q.subcategoryID = data.subcategoryID.ToString();
            q.parentID = data.parentID.ToString();
            q.answerTypeID = data.answerType.ToString();
            q.questionText = data.questionText;

            return q;
        }
    }
}