using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Business_Logic
{
    public static class QuestionProcessor
    {
        public static List<Question> LoadQuestions()
        {
            string sql = @"select Id, QuestionText, AnswerTypeID, ParentId, CategoryId, 
                        SubcategoryId from dbo.Questions";

            return SqlDataAccess.LoadData<Question>(sql);
        }

        public static List<Question> LoadChildrenOf(int id)
        {
            string sql = @"select Id, QuestionText, AnswerTypeID, ParentId, CategoryId, 
                        SubcategoryId from dbo.Questions where dbo.Questions.ParentID = " + id.ToString();

            return SqlDataAccess.LoadData<Question>(sql);
        }
    }
}
