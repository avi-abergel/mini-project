using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace Entities
{
    public class Messages
    {
        //a function tht inserts a message into the  user messages table in DB
        public void insertMessage(Message userMessage )
        {
            //connectiong to DB
            using(SqlConnection connection= new SqlConnection(ProductQuery.connectionString))
            { 
                //inserting data from the object i receives as a parametr to table 
                using (SqlCommand command = new SqlCommand("insert into UserMessages values(@userName, @userEmail, @userMessage)"))
                {
                    connection.Open();
                    //adding parameters to query with the values from the Message object i recieved as a parameter 
                    command.Parameters.AddWithValue("@userName", userMessage.Name);
                    command.Parameters.AddWithValue("@userEmail", userMessage.Email);
                    command.Parameters.AddWithValue("@userMessage", userMessage.UserMessage);
                    //executing command
                    command.ExecuteNonQuery();  

                }
            }
        }
    }
}