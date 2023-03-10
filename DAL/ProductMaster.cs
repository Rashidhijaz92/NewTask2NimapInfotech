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
    public class ProductMaster : ConnectionClass
    {
        public List<ProductModel> FillProduct()
        {
            this.Initialize();
            using (cnUniversal)
            {
                List<ProductModel> ProductList = new List<ProductModel>();
                cmdUniversal.CommandText = "FillProducttbl_SP";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;

                this.cnUniversal.Open();
                drUniveral = cmdUniversal.ExecuteReader();
                SqlDataReader dr = cmdUniversal.ExecuteReader();
                while (dr.Read())
                {
                    ProductModel Prod = new ProductModel();
                    Prod.ProductId = Convert.ToInt32(dr.GetValue(0));
                    Prod.CategoryName = dr.GetValue(1).ToString();
                    Prod.ProductName = dr.GetValue(2).ToString();
                    ProductList.Add(Prod);

                }
                cnUniversal.Close();

                return ProductList;
            }       //Using keyword automatically close the Connection After executing block
        }




        public bool CreateProduct(ProductModel product)
        {
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "InsertProduct_tbl_sp";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmdUniversal.Parameters.AddWithValue("@CategoryName", product.CategoryName);
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

        public bool EditProduct(ProductModel product)
        {
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "UpdateProduct_tbl_sp";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.AddWithValue("@ProductId", product.CategoryId);
                cmdUniversal.Parameters.AddWithValue("@CategoryName", product.CategoryName);
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

        public bool DeleteProduct(int ProductId)
        {
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "DeleteProduct_tbl_sp";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.AddWithValue("@ProductId", ProductId);
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
    }
}
