using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MainManager
    {
        private static readonly MainManager instance=new MainManager();
        public static MainManager Instance { get { return instance;  } }
        public  Products products =new Products();
        public  Messages messages= new Messages();
        //public static ProductQuery productQuery = new ProductQuery();  


        /*public static void init()
        {
            products.connectAndLoad();
        }*/
    }
}
