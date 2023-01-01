using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Model;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;
using Entities;
using System.Collections.Generic;

namespace MicroServer
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "delete", "update", Route = "Users/{action}/{idNumber?}")] HttpRequest req, string action, string idNumber,  
            ILogger log)
        {
            string reqBody;
            switch (action)
            {
                case "Get":
                    if (idNumber == null)
                    {
                        //string retJson = System.Text.Json.JsonSerializer.Serialize(MainManager.Instance.products.connectAndLoad());
                        return new OkObjectResult(System.Text.Json.JsonSerializer.Serialize(MainManager.Instance.products.connectAndLoad()));
                    }
                    else
                    {
                        string retJson= System.Text.Json.JsonSerializer.Serialize(MainManager.Instance.products.getProductByID(int.Parse(idNumber)));
                        return new OkObjectResult(retJson); 
                    }
                    break;
                case "Add":
                    reqBody=await new StreamReader(req.Body).ReadToEndAsync();
                    Message message =System.Text.Json.JsonSerializer.Deserialize<Message>(reqBody);
                    if(message.UserMessage!=null && message.Name!=null && message.Email!=null)
                    {
                        MainManager.Instance.messages.insertMessage(message);
                    }
                    return new OkObjectResult("request executed successfully");
                    break;
                case "update":
                    try 
                    {
                        reqBody = await new StreamReader(req.Body).ReadToEndAsync();
                        Product product = System.Text.Json.JsonSerializer.Deserialize<Product>(reqBody);
                        MainManager.Instance.products.updateProduct(int.Parse(idNumber), product.ProductName, product.categoryID, product.UnitsInStock);
                    }
                    catch (Exception ex) { Console.WriteLine(ex); }
                    return new OkResult();
                    break;

                case "Delete":
                    MainManager.Instance.products.deleteProductByID(int.Parse(idNumber));
                    return new OkResult();

                default:
                    return new BadRequestObjectResult("request failed");


                    


            }
        }
    }
}
