using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class ProfileModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string bio { get; set; }
        public string dp { get; set; }
        public string instagram { get; set; }
        public string linkedin { get; set; }
        public string github { get; set; }
    }
}
