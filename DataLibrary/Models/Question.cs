using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Question
    {
        public int Id;
        public string questionText;
        public int answerType;
        public int? parentID;
        public int categoryId;
        public int subcategoryID;
    }
}
