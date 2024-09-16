using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class DataBase
    {
        public static string SqlConnection
        {
            get{
                return ConfigurationManager.ConnectionStrings["NWConnectionString"].ConnectionString;

               }
        }

        public static SqlConnection GetSqlConnection()
        {
            SqlConnection connection = new SqlConnection(SqlConnection);
            connection.Open();


            return connection;
        }
    }
}
