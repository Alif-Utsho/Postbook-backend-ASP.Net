using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class ReportModel
    {
        public int id { get; set; }
        public int post_id { get; set; }
        public int user_id { get; set; }
        public string desc { get; set; }
        public System.DateTime created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    }
}
