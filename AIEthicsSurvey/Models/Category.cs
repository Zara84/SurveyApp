using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIEthicsSurvey.Models
{
    public class Category
    {
        public string Name;
        public int Id;
        public int rank;

        public List<DataLibrary.Models.Category> subcats = new List<DataLibrary.Models.Category>();
    }
}