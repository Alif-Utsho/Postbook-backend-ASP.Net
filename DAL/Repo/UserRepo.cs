using DAL.Database;
using DAL.iRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class UserRepo : iCrud<User, int>, iAuth
    {
        private DBEntities db;
        public UserRepo(DBEntities db)
        {
            this.db = db;
        }
        public bool Add(User model)
        {
            db.Users.Add(model);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.id == id);
            db.Users.Remove(user);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public User Get(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.id == id);
            return user;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public bool Update(User model)
        {
            User user = db.Users.FirstOrDefault(x => x.id == model.id);
            db.Entry(user).CurrentValues.SetValues(model);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public User Registration(User model)
        {
            db.Users.Add(model);
            if (db.SaveChanges() != 0) return model;
            return null;
        }

        public User Login(User model)
        {
            //var user = (from m in db.Users
            //            where m.email.Equals(model.email) &&
            //            m.password.Equals(model.password)
            //            select m).FirstOrDefault();
            var user = db.Users.Where(x => x.email.Equals(model.email) && x.password.Equals(model.password)).FirstOrDefault();
            return user;
        }
    }
}
