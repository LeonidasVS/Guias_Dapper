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

        public Customer ObtenerPorId(string id)
        {
            using(var conexion = DataBase.GetSqlConnection())
            {
                String selectPorID = "";
                selectPorID = selectPorID + "SELECT [CustomerID] " + "\n";
                selectPorID = selectPorID + "      ,[CompanyName] " + "\n";
                selectPorID = selectPorID + "      ,[ContactName] " + "\n";
                selectPorID = selectPorID + "      ,[ContactTitle] " + "\n";
                selectPorID = selectPorID + "      ,[Address] " + "\n";
                selectPorID = selectPorID + "      ,[City] " + "\n";
                selectPorID = selectPorID + "      ,[Region] " + "\n";
                selectPorID = selectPorID + "      ,[PostalCode] " + "\n";
                selectPorID = selectPorID + "      ,[Country] " + "\n";
                selectPorID = selectPorID + "      ,[Phone] " + "\n";
                selectPorID = selectPorID + "      ,[Fax] " + "\n";
                selectPorID = selectPorID + "  FROM [dbo].[Customers] " + "\n";
                selectPorID = selectPorID + "  WHERE CustomerID = @CustomerID";

                var Cliente = conexion.QueryFirstOrDefault<Customer>(selectPorID, new { CustomerID = id });
                return Cliente;
            }
        }

        public int InsertarClientes(Customer customer)
        {
            using (var conexion=DataBase.GetSqlConnection())
            {
                String InsertarCliente = "";
                InsertarCliente = InsertarCliente + "INSERT INTO [dbo].[Customers] " + "\n";
                InsertarCliente = InsertarCliente + "           ([CustomerID] " + "\n";
                InsertarCliente = InsertarCliente + "           ,[CompanyName] " + "\n";
                InsertarCliente = InsertarCliente + "           ,[ContactName] " + "\n";
                InsertarCliente = InsertarCliente + "           ,[ContactTitle] " + "\n";
                InsertarCliente = InsertarCliente + "           ,[Address]) " + "\n";
                InsertarCliente = InsertarCliente + "     VALUES " + "\n";
                InsertarCliente = InsertarCliente + "           (@customerID " + "\n";
                InsertarCliente = InsertarCliente + "           ,@companyName " + "\n";
                InsertarCliente = InsertarCliente + "           ,@contactName " + "\n";
                InsertarCliente = InsertarCliente + "           ,@contactTitle " + "\n";
                InsertarCliente = InsertarCliente + "           ,@address)";

                var insertados = conexion.Execute(InsertarCliente, new
                {
                    CustomerID = customer.CustomerID,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    Address = customer.Address,
                });
                return insertados;
            }
        }
    }
}
