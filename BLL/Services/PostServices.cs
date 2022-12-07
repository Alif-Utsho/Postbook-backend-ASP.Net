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
    public class PostServices
    {
        public static PostModel Get(int id)
        {
            var post = DataAccessFactory.PostDataAccess().Get(id);
            var postModel = new PostModel()
            {
                id = post.id,
                user_id = post.user_id,
                desc = post.desc,
                isComment = post.isComment,
                created_at = post.created_at,
                updated_at = post.updated_at
            };
            return postModel;
        }

        public static List<PostModel> Get()
        {
            var postList = DataAccessFactory.PostDataAccess().Get();
            var postModelList = new List<PostModel>();
            foreach(var post in postList)
            {
                var postModel = new PostModel()
                {
                    id = post.id,
                    user_id = post.user_id,
                    desc = post.desc,
                    isComment = post.isComment,
                    created_at = post.created_at,
                    updated_at = post.updated_at
                };
                postModelList.Add(postModel);
            }
            return postModelList;
        }

        public static bool Add(PostModel postModel)
        {
            var post = new Post()
            {
                user_id = postModel.user_id,
                desc = postModel.desc,
                isComment = postModel.isComment,
                created_at = postModel.created_at,
                updated_at = postModel.updated_at
            };
            return DataAccessFactory.PostDataAccess().Add(post);
        }

        public static bool Update(PostModel postModel)
        {
            var post = new Post()
            {
                id = postModel.id,
                user_id = postModel.user_id,
                desc = postModel.desc,
                isComment = postModel.isComment,
                created_at = postModel.created_at,
                updated_at = postModel.updated_at
            };
            return DataAccessFactory.PostDataAccess().Update(post);
        }

        public static bool Delete(int id)
        {
            DataAccessFactory.DeleteComment().DeleteByPostID(id);
            DataAccessFactory.DeleteReacts().DeleteByPostID(id);
            DataAccessFactory.DeleteReport().DeleteByPostID(id);
            return DataAccessFactory.PostDataAccess().Delete(id);
        }

        public static List<PostDetails> GetDetails()
        {
            var posts = DataAccessFactory.PostDetailsAccess().GetDetails();
            var postDetailsList = new List<PostDetails>();
            foreach(var post in posts)
            {
                var user = DataAccessFactory.UserDataAccess().Get(post.user_id);
                var userModel = new UserModel()
                {
                    id = user.id,
                    name = user.name,
                    phone = user.phone,
                    email = user.email,
                    type = user.type
                };
                var postDetails = new PostDetails()
                {
                    id = post.id,
                    user_id = post.user_id,
                    desc = post.desc,
                    isComment = post.isComment,
                    created_at = post.created_at,
                    updated_at = post.updated_at,
                    user = userModel
                };
                foreach (var comment in post.Comments)
                {
                    var cm = new CommentModel()
                    {
                        id = comment.id,
                        post_id = comment.post_id,
                        user_id = comment.user_id,
                        desc = comment.desc
                    };
                    postDetails.comments.Add(cm);
                }
                foreach (var react in post.Reacts)
                {
                    var rm = new ReactModel()
                    {
                        id = react.id,
                        user_id = react.user_id,
                        post_id = react.post_id
                    };
                    postDetails.reacts.Add(rm);
                }
                foreach (var report in post.Reports)
                {
                    var rm = new ReportModel()
                    {
                        id = report.id,
                        user_id = report.id,
                        post_id = report.post_id,
                        desc = report.desc,
                        created_at = report.created_at,
                        updated_at = report.updated_at
                    };
                    postDetails.reports.Add(rm);
                }
                postDetailsList.Add(postDetails);
            }
            return postDetailsList;
        }

        public static PostDetails GetDetails(int id)
        {
            var post = DataAccessFactory.PostDetailsAccess().GetDetails(id);
            var user = DataAccessFactory.UserDataAccess().Get(post.user_id);
            var userModel = new UserModel()
            {
                id = user.id,
                name = user.name,
                phone = user.phone,
                email = user.email,
                type = user.type
            };
            var postDetails = new PostDetails()
            {
                id = post.id,
                user_id = post.user_id,
                desc = post.desc,
                isComment = post.isComment,
                created_at = post.created_at,
                updated_at = post.updated_at,
                user = userModel
            };
            foreach (var comment in post.Comments)
            {
                var cm = new CommentModel()
                {
                    id = comment.id,
                    post_id = comment.post_id,
                    user_id = comment.user_id,
                    desc = comment.desc
                };
                postDetails.comments.Add(cm);
            }
            foreach (var react in post.Reacts)
            {
                var rm = new ReactModel()
                {
                    id = react.id,
                    user_id = react.user_id,
                    post_id = react.post_id
                };
                postDetails.reacts.Add(rm);
            }
            foreach (var report in post.Reports)
            {
                var rm = new ReportModel()
                {
                    id = report.id,
                    user_id = report.id,
                    post_id = report.post_id,
                    desc = report.desc,
                    created_at = report.created_at,
                    updated_at = report.updated_at
                };
                postDetails.reports.Add(rm);
            }
            return postDetails;
        }

        public static List<PostModel> GetPostOfUser(int id)
        {
            var postList = DataAccessFactory.GetPostOfUser().Get(id);
            var postModelList = new List<PostModel>();
            foreach (var post in postList)
            {
                var postModel = new PostModel()
                {
                    id = post.id,
                    user_id = post.user_id,
                    desc = post.desc,
                    isComment = post.isComment,
                    created_at = post.created_at,
                    updated_at = post.updated_at
                };
                postModelList.Add(postModel);
            }
            return postModelList;
        }

        public static List<PostDetails> GetPostDetailsOfUser(int id)
        {
            var posts = DataAccessFactory.GetPostOfUser().Get(id);
            var postDetailsList = new List<PostDetails>();
            foreach (var post in posts)
            {
                var user = DataAccessFactory.UserDataAccess().Get(post.user_id);
                var userModel = new UserModel()
                {
                    id = user.id,
                    name = user.name,
                    phone = user.phone,
                    email = user.email,
                    type = user.type
                };
                var postDetails = new PostDetails()
                {
                    id = post.id,
                    user_id = post.user_id,
                    desc = post.desc,
                    isComment = post.isComment,
                    created_at = post.created_at,
                    updated_at = post.updated_at,
                    user = userModel
                };
                foreach (var comment in post.Comments)
                {
                    var cm = new CommentModel()
                    {
                        id = comment.id,
                        post_id = comment.post_id,
                        user_id = comment.user_id,
                        desc = comment.desc
                    };
                    postDetails.comments.Add(cm);
                }
                foreach (var react in post.Reacts)
                {
                    var rm = new ReactModel()
                    {
                        id = react.id,
                        user_id = react.user_id,
                        post_id = react.post_id
                    };
                    postDetails.reacts.Add(rm);
                }
                foreach (var report in post.Reports)
                {
                    var rm = new ReportModel()
                    {
                        id = report.id,
                        user_id = report.id,
                        post_id = report.post_id,
                        desc = report.desc,
                        created_at = report.created_at,
                        updated_at = report.updated_at
                    };
                    postDetails.reports.Add(rm);
                }
                postDetailsList.Add(postDetails);
            }
            return postDetailsList;
        }
    }
}
