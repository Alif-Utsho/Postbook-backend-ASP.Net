using DAL.Database;
using DAL.iRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class ReactRepo : iCrud<React, int>, iDeleteByPostID<React, int>, iFindByPostID<React, int>, iDeleteByUserPostID<int, int>
    {
        private DBEntities db;
        public ReactRepo(DBEntities db)
        {
            this.db = db;
        }

        public bool Add(React model)
        {
            db.Reacts.Add(model);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var react = db.Reacts.FirstOrDefault(x => x.id == id);
            db.Reacts.Remove(react);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public React Get(int id)
        {
            return db.Reacts.FirstOrDefault(x => x.id == id);
        }

        public List<React> Get()
        {
            return db.Reacts.ToList();
        }

        public bool Update(React model)
        {
            var react = db.Reacts.FirstOrDefault(x => x.id == model.id);
            db.Entry(react).CurrentValues.SetValues(model);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool DeleteByPostID(int postId)
        {
            var res = from r in db.Reacts
                      where r.post_id == postId
                      select r;
            foreach(var r in res)
            {
                db.Reacts.Remove(r);
            }
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        List<React> iFindByPostID<React, int>.Get(int post_id)
        {
            return db.Reacts.Where(x => x.post_id == post_id).ToList();
        }

        public bool Delete(int user_id, int post_id)
        {
            var res = from r in db.Reacts
                      where r.post_id == post_id && r.user_id == user_id
                      select r;
            foreach (var r in res)
            {
                db.Reacts.Remove(r);
            }
            if (db.SaveChanges() != 0) return true;
            return false;
        }
    }
}
