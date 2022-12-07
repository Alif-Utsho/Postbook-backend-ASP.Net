using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.iRepo
{
    public interface iDetails<T, ID>
    {
        List<T> GetDetails();
        T GetDetails(ID id);
    }
}
