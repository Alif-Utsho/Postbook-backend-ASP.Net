using BLL.Entities;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PostController : ApiController
    {
        [Route("api/posts")]
        [HttpGet]
        public HttpResponseMessage Posts()
        {
            var postDetails = PostServices.GetDetails();
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                posts = postDetails,
            });
        }

        [Route("api/createpost")]
        [HttpPost]
        public HttpResponseMessage Create(PostModel postModel)
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            postModel.user_id = token.user_id;
            postModel.created_at = System.DateTime.Now;
            postModel.updated_at = postModel.created_at;
            postModel.isComment = true;
            var res = PostServices.Add(postModel);
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.Created, new
                {
                    post = postModel.desc,
                    message = "New Post Created Successfully"
                });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                message = "Something Went Wrong"
            });
        }

        [Route("api/deletepost")]
        [HttpPut]
        public HttpResponseMessage Delete(PostModel post)
        {
            var react = ReactServices.DeleteByPostID(post.id);
            var comment = CommentServices.DeleteByPostID(post.id);
            var report = ReportServices.DeleteByPostID(post.id);
            var res = PostServices.Delete(post.id);
            
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    message = "Post Deleted Successfully"
                });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                message = "Something Went Wrong"
            });
        }
        
        [Route("api/postofuser/auth")]
        [HttpGet]
        public HttpResponseMessage PostOfUser()
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            var posts = PostServices.GetPostDetailsOfUser(token.user_id);
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                posts = posts
            });
        }
        [Route("api/postofuser/{id}")]
        [HttpGet]
        public HttpResponseMessage PostOfUser(int id)
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            var posts = PostServices.GetPostDetailsOfUser(id);
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                posts = posts,
                authId = token.user_id
            });
        }

        [Route("api/post/{id}")]
        [HttpGet]
        public HttpResponseMessage SinglePost(int id)
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            var post = PostServices.GetDetails(id);
            var user = UserServices.Get(token.user_id);
            var profile = ProfileServices.Get(token.user_id);
            var send_byfriends = ConnectionServices.SentByFriends(token.user_id);
            var rec_byfriends = ConnectionServices.RecByFriends(token.user_id);
            var requests = ConnectionServices.GetRequests(token.user_id);
            var sents = ConnectionServices.GetSents(token.user_id);
            var posts = PostServices.GetPostOfUser(token.user_id);

            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                post = post,
                authuser = new
                {
                    user.id,
                    user.name,
                    user.phone,
                    user.email,
                    user.type,
                    profile = profile,
                    send_byfriends = send_byfriends,
                    rec_byfriends = rec_byfriends,
                    request = requests,
                    sent = sents,
                    posts = posts
                }
            });
        }

        [Route("api/editpost")]
        [HttpPut]
        public HttpResponseMessage Edit(PostModel postModel)
        {
            var post = PostServices.Get(postModel.id);
            post.id = postModel.id;
            post.desc = postModel.desc;
            post.updated_at = System.DateTime.Now;
            var res = PostServices.Update(post);
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    message = "Post Updated Successfully"
                });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                message = "Something Went Wrong"
            });
        }

        [Route("api/commentoff")]
        [HttpPut]
        public HttpResponseMessage CommentOff(PostModel postModel)
        {
            var post = PostServices.Get(postModel.id);
            post.isComment = false;
            var res = PostServices.Update(post);
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    message = "The post won't take any comment"
                });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                message = "Something Went Wrong"
            });
        }

        [Route("api/commenton")]
        [HttpPut]
        public HttpResponseMessage CommentOn(PostModel postModel)
        {
            var post = PostServices.Get(postModel.id);
            post.isComment = true;
            var res = PostServices.Update(post);
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    message = "The post will take your friends comment"
                });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                message = "Something Went Wrong"
            });
        }

    }
}
