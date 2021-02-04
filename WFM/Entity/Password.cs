using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFM.Entity
{
    public class Password
    {
        public User user { get; set; }
        public int id { get; set; }
        public string password { get; set; }
        public int passwordStatus { get; set; }
    }
}
