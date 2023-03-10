using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MODEL;

namespace BAL
{

    public class ProductCategoryDetail
    {
        ProductCategoryDetails dal = new ProductCategoryDetails();

        public List<ProductDetailModel> GetAllProduct()
        {
            return dal.GetAllProduct();
        }

        public bool InsertCategory(CategoryModel CatModel)
        {
            return dal.AddCategory(CatModel);
        }


        public DataSet GetAllcatMaster()
        {
            return dal.GetAllcatMaster();

        }
    }

}
