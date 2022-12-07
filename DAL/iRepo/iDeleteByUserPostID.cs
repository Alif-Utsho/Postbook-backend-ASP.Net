using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.iRepo
{
    public interface iDeleteByUserPostID<Uid, Pid>
    {
        bool Delete(Uid user_id, Pid post_id);
    }
}
