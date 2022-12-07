using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.iRepo
{
    public interface iConDetails<T, ID>
    {
        List<T> GetRequests(ID id);
        List<T> GetSents(ID id);
        List<T> GetFriends(ID id);
        List<T> SentByFriends(ID id);
        List<T> RecByFriends(ID id);
    }
}
