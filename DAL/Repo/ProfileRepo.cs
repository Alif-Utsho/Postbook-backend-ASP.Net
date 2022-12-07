using DAL.Database;
using DAL.iRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class ProfileRepo : iCrud<Profile, int>
    {
        private DBEntities db;
        public ProfileRepo(DBEntities db)
        {
            this.db = db;
        }

        public bool Add(Profile model)
        {
            db.Profiles.Add(model);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var profile = db.Profiles.FirstOrDefault(x => x.user_id == id);
            db.Profiles.Remove(profile);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public Profile Get(int id)
        {
            return db.Profiles.FirstOrDefault(x => x.user_id == id);
        }

        public List<Profile> Get()
        {
            return db.Profiles.ToList();
        }

        public bool Update(Profile model)
        {
            var profile = db.Profiles.FirstOrDefault(x => x.id == model.id);
            db.Entry(profile).CurrentValues.SetValues(model);
            if (db.SaveChanges() != 0) return true;
            return false;
        }
    }
}
