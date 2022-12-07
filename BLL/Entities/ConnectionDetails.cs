using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class ConnectionDetails
    {
        public int id { get; set; }
        public UserModel sender { get; set; }
        public UserModel receiver { get; set; }
        public string status { get; set; }
        public ProfileModel sender_profile { get; set; }
        public ProfileModel receiver_profile { get; set; }
    }
}
