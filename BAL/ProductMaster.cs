using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MODEL;

namespace BAL
{
    public class ProductMasterr
    {
        ProductMaster ProDalClass = new ProductMaster();

        public List<ProductModel> FillProduct()
        {
            return ProDalClass.FillProduct();
        }

        public bool CreateProduct(ProductModel product)
        {
            return ProDalClass.CreateProduct(product);

        }
        public bool EditProduct(ProductModel product)
        {
            return ProDalClass.EditProduct(product);
        }

        public bool DeleteProduct(int CategoryId)
        {
            return ProDalClass.DeleteProduct(CategoryId);   

        }

    }
}
