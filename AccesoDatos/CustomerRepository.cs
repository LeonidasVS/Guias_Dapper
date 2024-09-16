using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CustomerRepository
    {
        public List<Customer> obtenerTodo()
        {
            using (var conexion=DataBase.GetSqlConnection())
            {
                String SelectFrom = "";
                SelectFrom = SelectFrom + "SELECT [CustomerID] " + "\n";
                SelectFrom = SelectFrom + "      ,[CompanyName] " + "\n";
                SelectFrom = SelectFrom + "      ,[ContactName] " + "\n";
                SelectFrom = SelectFrom + "      ,[ContactTitle] " + "\n";
                SelectFrom = SelectFrom + "      ,[Address] " + "\n";
                SelectFrom = SelectFrom + "      ,[City] " + "\n";
                SelectFrom = SelectFrom + "      ,[Region] " + "\n";
                SelectFrom = SelectFrom + "      ,[PostalCode] " + "\n";
                SelectFrom = SelectFrom + "      ,[Country] " + "\n";
                SelectFrom = SelectFrom + "      ,[Phone] " + "\n";
                SelectFrom = SelectFrom + "      ,[Fax] " + "\n";
                SelectFrom = SelectFrom + "  FROM [dbo].[Customers]";

                var clientes = conexion.Query<Customer>(SelectFrom).ToList();
                return clientes;


            }

        }
    }
}
