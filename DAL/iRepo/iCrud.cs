using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.iRepo
{
    public interface iCrud<T, ID>
    {
        T Get(ID id);
        List<T> Get();
        bool Add(T model);
        bool Delete(ID id);
        bool Update(T model);
    }
}
