using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Business_Logic
{
    public static class CategoryProcessor
    {
        public static List<Category> CategoryLoader()
        {
            string sql = @"select Id, Name from dbo.Categories";

            return SqlDataAccess.LoadData<Category>(sql);
        }

        public static List<Category> SubCategoriesOf(int i)
        {
            string sql = @"select Id, Name from dbo.Subcategories where dbo.Subcategories.ParentId = " + i.ToString();

            return SqlDataAccess.LoadData<Category>(sql);
        }
    }
}
