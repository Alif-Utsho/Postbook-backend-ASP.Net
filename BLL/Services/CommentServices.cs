using BLL.Entities;
using DAL;
using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CommentServices
    {
        public static CommentModel Get(int id)
        {
            var comment = DataAccessFactory.CommentDataAccess().Get(id);
            var commentModel = new CommentModel()
            {
                id = comment.id,
                post_id = comment.post_id,
                user_id = comment.user_id,
                desc = comment.desc
            };
            return commentModel;
        }

        public static List<CommentModel> Get()
        {
            var commentList = DataAccessFactory.CommentDataAccess().Get();
            var commentModelList = new List<CommentModel>();
            foreach(var comment in commentList)
            {
                var commentModel = new CommentModel()
                {
                    id = comment.id,
                    post_id = comment.post_id,
                    user_id = comment.user_id,
                    desc = comment.desc
                };
                commentModelList.Add(commentModel);
            }
            return commentModelList;
        }

        public static bool Add(CommentModel commentModel)
        {
            var comment = new Comment()
            {
                post_id = commentModel.post_id,
                user_id = commentModel.user_id,
                desc = commentModel.desc
            };
            return DataAccessFactory.CommentDataAccess().Add(comment);
        }

        public static bool Update(CommentModel commentModel)
        {
            var comment = new Comment()
            {
                id = commentModel.id,
                post_id = commentModel.post_id,
                user_id = commentModel.user_id,
                desc = commentModel.desc
            };
            return DataAccessFactory.CommentDataAccess().Update(comment);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.CommentDataAccess().Delete(id);
        }

        public static List<CommentModel> GetByPostID(int id)
        {
            var comments = DataAccessFactory.GetComments().Get(id);
            var commentModelList = new List<CommentModel>();
            foreach (var comment in comments)
            {
                var commentModel = new CommentModel()
                {
                    id = comment.id,
                    user_id = comment.user_id,
                    post_id = comment.post_id,
                    desc = comment.desc,
                };
                commentModelList.Add(commentModel);
            }
            return commentModelList;
        }

        public static bool DeleteByPostID(int id)
        {
            return DataAccessFactory.DeleteComment().DeleteByPostID(id);
        }
    }
}
