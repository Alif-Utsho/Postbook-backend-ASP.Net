using DAL.Database;
using DAL.iRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class PostRepo : iCrud<Post, int>, iDetails<Post, int>, iFindByUserID<Post, int>
    {
        private DBEntities db;
        public PostRepo(DBEntities db)
        {
            this.db = db;
        }

        public bool Add(Post model)
        {
            db.Posts.Add(model);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var post = db.Posts.FirstOrDefault(x => x.id == id);
            db.Posts.Remove(post);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public Post Get(int id)
        {
            return db.Posts.FirstOrDefault(x => x.id == id);
        }

        public List<Post> Get()
        {
            return db.Posts.ToList();
        }

        public bool Update(Post model)
        {
            var post = db.Posts.FirstOrDefault(x => x.id == model.id);
            db.Entry(post).CurrentValues.SetValues(model);
            if (db.SaveChanges() != 0) return true;
            return false;
        }


        public List<Post> GetDetails()
        {
            //var posts = (from p in db.Posts
            //            join c in db.Comments on p.id equals c.post_id into com
            //            join r in db.Reacts on p.id equals r.post_id into rec
            //            join rp in db.Reports on p.id equals rp.post_id into rep
            //            select new
            //            {
            //                p.id, p.desc,p.user_id, p.isComment, p.created_at, p.updated_at,
            //                Comments = com, Reacts = rec, Reports = rep
            //            }).ToList();
            return db.Posts.ToList();
        }

        public Post GetDetails(int id)
        {
            //var post = (from p in db.Posts where p.id == id
            //             join c in db.Comments on p.id equals c.post_id into com
            //             join r in db.Reacts on p.id equals r.post_id into rec
            //             join rp in db.Reports on p.id equals rp.post_id into rep
            //             select new
            //             {
            //                 p.id, p.desc, p.user_id, p.isComment, p.created_at, p.updated_at,
            //                 Comments = com, Reacts = rec, Reports = rep
            //             }).FirstOrDefault();
            return db.Posts.FirstOrDefault(x => x.id == id);
        }

        List<Post> iFindByUserID<Post, int>.Get(int id)
        {
            return db.Posts.Where(x => x.user_id == id).ToList();
        }

    }
}


