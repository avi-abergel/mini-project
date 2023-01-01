using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Model;

namespace DAL
{
    public class ProductQuery
    {
        public delegate Dictionary<int,Product> connectNorthwind_delegate(SqlDataReader reader);
        public static string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=localhost\\SQLEXPRESS";
        public static Dictionary<int,Product> ConnectToDB(string query, connectNorthwind_delegate func)
        {
            //connecting to db
             
            using(SqlConnection connection= new SqlConnection(connectionString))
            {
                //string query = "select *from products";
                using(SqlCommand command= new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                         return func(reader);
                    }
                }
            }
        }
	
       
    }
}
