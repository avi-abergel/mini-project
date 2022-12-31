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
        public static Products products =new Products();
        public static ProductQuery productQuery = new ProductQuery();   
        public static void init()
        {
            products.connectAndLoad();
        }
    }
}
