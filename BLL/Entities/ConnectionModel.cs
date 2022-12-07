using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class ConnectionModel
    {
        public int id { get; set; }
        public int sender { get; set; }
        public int receiver { get; set; }
        public string status { get; set; }
    }
}
