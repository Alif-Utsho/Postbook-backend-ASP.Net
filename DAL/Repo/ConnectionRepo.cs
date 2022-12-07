using DAL.Database;
using DAL.iRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class ConnectionRepo : iCrud<Connection, int>, iConDetails<Connection, int>
    {
        private DBEntities db;
        public ConnectionRepo(DBEntities db)
        {
            this.db = db;
        }

        public bool Add(Connection model)
        {
            db.Connections.Add(model);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var connection = db.Connections.FirstOrDefault(x => x.id == id);
            db.Connections.Remove(connection);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public Connection Get(int id)
        {
            return db.Connections.FirstOrDefault(x => x.id == id);
        }

        public List<Connection> Get()
        {
            return db.Connections.ToList();
        }

        public bool Update(Connection model)
        {
            var connection = db.Connections.FirstOrDefault(x => x.id == model.id);
            db.Entry(connection).CurrentValues.SetValues(model);
            if (db.SaveChanges() != 0) return true;
            return false;
        }


        public List<Connection> GetRequests(int id)
        {
            var connections = (from c in db.Connections
                               where c.receiver == id && c.status.Equals("follower")
                               select c).ToList();
            return connections;
        }
        public List<Connection> GetSents(int id)
        {
            var connections = (from c in db.Connections
                               where c.sender == id && c.status.Equals("follower")
                               select c).ToList();
            return connections;
        }
        public List<Connection> GetFriends(int id)
        {
            var connections = (from c in db.Connections
                               where (c.sender == id || c.receiver == id) && c.status.Equals("friend")
                               select c).ToList();
            return connections;
        }

        public List<Connection> SentByFriends(int id)
        {
            var connections = (from c in db.Connections
                               where c.sender == id  && c.status.Equals("friend")
                               select c).ToList();
            return connections;
        }

        public List<Connection> RecByFriends(int id)
        {
            var connections = (from c in db.Connections
                               where c.receiver == id && c.status.Equals("friend")
                               select c).ToList();
            return connections;
        }
    }
}
