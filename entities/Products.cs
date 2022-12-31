using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities
{
    public class Products
    {
       public void connectAndLoad()
        {
            ProductQuery.ConnectToDB("select * from Products", AddProduct);
        }
        
        //a function that loads the dictionary with a product that his data is from the DB
        public Dictionary<int, Product> AddProduct(SqlDataReader reader)
        {
            //creating a products dictionary
            Dictionary<int, Product> productsDic = new Dictionary<int, Product>();
            //loading a product with data from the DB
            while (reader.Read())
            {
                Product product = new Product();
                product.ProductID = reader.GetInt32(reader.GetOrdinal("ProductID"));
                product.ProductName = reader.GetString(reader.GetOrdinal("ProductName"));
                product.SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID"));
                product.categoryID = reader.GetInt32(reader.GetOrdinal("categoryID"));
                product.quantityPerUnit = reader.GetString(reader.GetOrdinal("quantityPerUnit"));
                product.UnitPrice = reader.GetSqlMoney(reader.GetOrdinal("UnitPrice"));
                product.UnitsInStock = reader.GetInt32(reader.GetOrdinal("UnitsInStock"));
                product.UnitsOnOrder = reader.GetInt32(reader.GetOrdinal("UnitsOnOrder"));
                product.ReorderLevel = reader.GetInt32(reader.GetOrdinal("ReorderLevel"));
                product.Discontinued = reader.GetBoolean(reader.GetOrdinal("Discontinued"));
                //addding product to the products dictionary
                productsDic.Add(product.ProductID, product);
            }
            return productsDic;

        }
        //function that returns a product from the dictionary by its ID
        public Product getProductByID(Dictionary<int, Product> ProductsDic, int key)
        {
            Product ProductFromDic = new Product();
            ProductFromDic = ProductsDic[key];
            return ProductFromDic;
        }

        //function that updated=s product's details in the DB
        public void updateProduct(int productID, string productName, int categoryID, int unitsInStock)
        {
            //connecting to DB
            using (SqlConnection connection = new SqlConnection(ProductQuery.connectionString))
            {
                //update query
                using (SqlCommand command = new SqlCommand("update Products set ProductID=@productID ProductName=@productName CategoryID=@categoryID UnitsInStock=@unitsInStock", connection)) 
                {
                    connection.Open();
                    //adding parameters with the updated values
                    command.Parameters.AddWithValue("@productID", productID);
                    command.Parameters.AddWithValue("@productName", productName);
                    command.Parameters.AddWithValue("@categoryID", categoryID);
                    command.Parameters.AddWithValue("@unitsInStock", unitsInStock);

                    //executing the update command with the updated parameters
                    command.ExecuteNonQuery();
                }
            }
        }

        //function that delets product from the DB by its ID
        public void deleteProductByID(int productID)
        {
            //connecting to DB
            using (SqlConnection connection= new SqlConnection(ProductQuery.connectionString))
            {
                //delete query
                using(SqlCommand command=new SqlCommand("delete from Products where ProductID=@productID", connection))
                {
                    connection.Open();
                    //adding the product's ID as a parameter
                    command.Parameters.AddWithValue("@productId", productID);
                    //executing the delete command 
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
