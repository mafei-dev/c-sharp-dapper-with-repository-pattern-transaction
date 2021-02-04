using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFM.Resources
{
    public static class Helper
    {
        public static string GetConnectionString() 
        {
            return ConfigurationManager.ConnectionStrings["TEST"].ConnectionString;
        }
     }
}
