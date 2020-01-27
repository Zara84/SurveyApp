using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIEthicsSurvey.Models
{
    public enum AnswerType
    {
        Binary,
        Text,
        Multiple
    };

    public class Question
    {
        public int ID { get; set; }

        public string questionText { get; set; }

        public string answerTypeID { get; set; }

        public List<AIEthicsSurvey.Models.Question> children = new List<AIEthicsSurvey.Models.Question>();

        public string categoryID;

        public string subcategoryID;

        public string parentID;

        public Question()
        {

        }

        public Question(int ID)
        {
            this.ID = ID;
        }
    }

    public class Answer
    {
        public AnswerType answerType { get; set; }
    }

    public class BinaryAnswer: Answer
    {
        public bool value { get; set; }
    }

    public class TextAnswer: Answer
    {
        public string value { get; set; }
    }

    public class MultipleAnswer: Answer
    {
        public List<string> value = new List<string>();
    }

    
}