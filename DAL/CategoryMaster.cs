using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;

namespace DAL
{
    public class CategoryMaster:ConnectionClass
    {

        //crud CategoryMaster
        public List<CategoryModel> FillCategory()
        {
            List<CategoryModel> CategoryList = new List<CategoryModel>();

            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "FillCategorytbl_SP";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                while (drUniveral.Read())
                {
                    CategoryModel catModel = new CategoryModel();
                    catModel.CategoryId = Convert.ToInt32(drUniveral.GetValue(0).ToString());
                    catModel.CategoryName = drUniveral.GetValue(1).ToString();
                    CategoryList.Add(catModel);

                }
                this.Close();
            }//Using keyword automatically close the Connection After executing block

            return CategoryList;
        }

        public bool CreateCategory(Category category)
        {
            this.Initialize();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "InsertCategorytbl_sp";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.AddWithValue("@CategoryName", category.CategoryName);
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
        public bool EditCategory(Category category, int CategoryId)
        {
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "UpdateCategorytbl_sp";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.AddWithValue("@CategoryId", CategoryId);
                cmdUniversal.Parameters.AddWithValue("@CategoryName", category.CategoryName);
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
        public bool DeleteCategor(int CategoryId)
        {
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "DeleteCategorytbl_sp";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.AddWithValue("@CategoryId", CategoryId);
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
