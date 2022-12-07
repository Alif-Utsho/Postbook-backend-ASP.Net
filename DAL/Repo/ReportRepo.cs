using DAL.Database;
using DAL.iRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class ReportRepo : iCrud<Report, int>, iDeleteByPostID<Report, int>, iFindByPostID<Report, int>
    {
        private DBEntities db;
        public ReportRepo(DBEntities db)
        {
            this.db = db;
        }
        public bool Add(Report model)
        {
            db.Reports.Add(model);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var report = db.Reports.FirstOrDefault(x => x.id == id);
            db.Reports.Remove(report);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public Report Get(int id)
        {
            return db.Reports.FirstOrDefault(x => x.id == id);
        }

        public List<Report> Get()
        {
            return db.Reports.ToList();
        }

        public bool Update(Report model)
        {
            var report = db.Reports.FirstOrDefault(x => x.id == model.id);
            db.Entry(report).CurrentValues.SetValues(model);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool DeleteByPostID(int postId)
        {
            var res = from r in db.Reports
                      where r.post_id == postId
                      select r;
            foreach (var r in res)
            {
                db.Reports.Remove(r);
            }
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        List<Report> iFindByPostID<Report, int>.Get(int post_id)
        {
            return db.Reports.Where(x => x.post_id == post_id).ToList();
        }
    }
}
