using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace DAL
{
    public class ProductCategoryDetails:ConnectionClass
    {


        public List<ProductDetailModel> GetAllProduct()
        {
            List<ProductDetailModel> productDetails = new List<ProductDetailModel>();

            using (cnUniversal)//Using keyword automatically close the Connection After executing block
            {
                cmdUniversal.CommandText = "GetAllProductDetails_sp";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cnUniversal.Open();

                while (drUniveral.Read())
                {
                    productDetails.Add(
                            new ProductDetailModel
                            {
                                ProductId = Convert.ToInt32(drUniveral["ProductId"]),
                                ProductName = Convert.ToString(drUniveral["ProductName"]),
                                CategoryId = Convert.ToInt32(drUniveral["CategoryId"]),
                                CategoryName = Convert.ToString(drUniveral["CategoryName"])

                            });

                }
                cnUniversal.Close();

                return productDetails;

            }
        }

      

        public bool AddCategory(CategoryModel CatModel)
        {
            this.Initialize();
            using(cnUniversal)
            {
                cmdUniversal.CommandText = "GetAllProductDetails_sp";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.AddWithValue("@CategoryName", CatModel.CategoryName);
                cmdUniversal.Parameters.AddWithValue("@Product", CatModel.Product);
                cnUniversal.Open();
                int i = cmdUniversal.ExecuteNonQuery();
                cnUniversal.Close();

                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

           

           
        }

        public DataSet GetAllcatMaster()
        {
            DataSet ds = new DataSet();

            try
            {
                this.Initialize();
                using (cnUniversal)
                {
                    cmdUniversal.CommandText = "GetAllcatMaster_sp";
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    cnUniversal.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmdUniversal);
                    da.Fill(ds);

                }//Using keyword automatically close the Connection After executing block
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cnUniversal.Close();
            }
            return ds;
        }

    }
}
