using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class TokenModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string type { get; set; }
        public string token1 { get; set; }
        public bool expired { get; set; }
    }
}
