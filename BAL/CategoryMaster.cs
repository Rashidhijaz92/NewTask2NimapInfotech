using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MODEL;

namespace BAL
{

    public class CategoryMasterr
    {
        CategoryMaster DAlcat = new CategoryMaster();

        public List<CategoryModel> FillCategory()
        {
            return DAlcat.FillCategory();
        }
        public bool CreateCategory(Category category)
        {
            return DAlcat.CreateCategory(category);
        }
        public bool EditCategory(Category category, int CategoryId)
        {
            return DAlcat.EditCategory(category, CategoryId);
        }
        public bool DeleteCategor(int CategoryId)
        {
            return DAlcat.DeleteCategor(CategoryId);
        }
    }
}
