using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConnectionClass
    {
        internal static string conn;
        internal SqlConnection cnUniversal;
        internal SqlCommand cmdUniversal;
        internal SqlDataAdapter daUniversal;
        
        internal SqlDataReader drUniveral;

        public ConnectionClass()
        {
            conn = @"Data Source=RASHIDSHAIKH;Initial Catalog=NimapDB;Integrated Security=True";
        }

        
        public virtual void Initialize()
        {
            try
            {
                cnUniversal = new SqlConnection(conn);
                daUniversal = new SqlDataAdapter();
                cmdUniversal = new SqlCommand();
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Connection = cnUniversal;
                drUniveral = cmdUniversal.ExecuteReader();
            }

            catch (Exception e)
            {
                ErrorLog("dbBasis initialization", e);
            }
        }
        public virtual void Close()
        {
            if (cnUniversal.State != System.Data.ConnectionState.Closed)
                cnUniversal.Close();
        }

        protected virtual void ErrorLog(string strMessage, Exception e)
        {
            Exception oException = new Exception(e.InnerException.Message + " \n\n Details:" + strMessage);
            throw oException;
        }


    }
}
