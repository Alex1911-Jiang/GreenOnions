using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GreenOnions.Utility.Helper
{
    public static class SqlHelper
    {
        public static DataSet Select(string sql, string dataBaseName = "GreenOnions")
        {
            string _ConnStr = ConfigurationManager.ConnectionStrings[dataBaseName + "ConnectString"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(_ConnStr))
            {
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    using (SqlDataAdapter SelectAdapter = new SqlDataAdapter())
                    {
                        SelectAdapter.SelectCommand = sqlCommand;
                        DataSet ds = new DataSet();
                        SelectAdapter.SelectCommand.ExecuteNonQuery();
                        SelectAdapter.Fill(ds);
                        return ds;
                    }
                }
            }
        }
    }
}
