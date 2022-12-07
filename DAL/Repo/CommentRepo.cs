using DAL.Database;
using DAL.iRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class CommentRepo : iCrud<Comment, int>, iDeleteByPostID<Comment, int>, iFindByPostID<Comment, int>
    {
        private DBEntities db;
        public CommentRepo(DBEntities db)
        {
            this.db = db;
        }

        public bool Add(Comment model)
        {
            db.Comments.Add(model);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var comment = db.Comments.FirstOrDefault(x => x.id == id);
            db.Comments.Remove(comment);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public Comment Get(int id)
        {
            return db.Comments.FirstOrDefault(x => x.id == id);
        }

        public List<Comment> Get()
        {
            return db.Comments.ToList();
        }

        public bool Update(Comment model)
        {
            var comment = db.Comments.FirstOrDefault(x => x.id == model.id);
            db.Entry(comment).CurrentValues.SetValues(model);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool DeleteByPostID(int postId)
        {
            var res = from r in db.Comments
                      where r.post_id == postId
                      select r;
            foreach (var c in res)
            {
                db.Comments.Remove(c);
            }
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        List<Comment> iFindByPostID<Comment, int>.Get(int post_id)
        {
            return db.Comments.Where(x => x.post_id == post_id).ToList();
        }
    }
}
