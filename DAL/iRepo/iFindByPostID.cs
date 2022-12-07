using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.iRepo
{
    public interface iFindByPostID<T, ID>
    {
        List<T> Get(ID post_id);
    }
}
