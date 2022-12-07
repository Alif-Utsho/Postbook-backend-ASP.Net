using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class PostDetails
    {
        public PostDetails()
        {
            this.comments = new HashSet<CommentModel>();
            this.reacts = new HashSet<ReactModel>();
            this.reports = new HashSet<ReportModel>();
            this.user = new UserModel();
        }

        public int id { get; set; }
        public int user_id { get; set; }
        public string desc { get; set; }
        public bool isComment { get; set; }
        public UserModel user { get; set; }
        public System.DateTime created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }

        public virtual ICollection<CommentModel> comments { get; set; }
        public virtual ICollection<ReactModel> reacts { get; set; }
        public virtual ICollection<ReportModel> reports { get; set; }
    }
}
