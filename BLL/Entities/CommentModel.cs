using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class CommentModel
    {
        public int id { get; set; }
        public int post_id { get; set; }
        public int user_id { get; set; }
        public string desc { get; set; }
    }
}
