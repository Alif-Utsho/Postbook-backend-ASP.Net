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
    public class CommentController : ApiController
    {
        [Route("api/comments/{post_id}")]
        [HttpGet]
        public HttpResponseMessage Comments(int post_id)
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            var comments = CommentServices.GetByPostID(post_id);
            var commentDetails = new List<Object>();
            foreach (var comment in comments)
            {
                var user = UserServices.Get(comment.user_id);
                commentDetails.Add(new
                {
                    comment.id,
                    comment.user_id,
                    comment.post_id,
                    comment.desc,
                    user = user
                });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                comments = commentDetails
                //authId = token.user_id
            });
        }

        [Route("api/createcomment")]
        [HttpPost]
        public HttpResponseMessage CreateComment(CommentModel comment)
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            comment.user_id = token.user_id;
            var res = CommentServices.Add(comment);
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    message = "Your comment submitted successfully"
                });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                message = "Something went Wrong"
            });
        }

        [Route("api/deletecomment")]
        [HttpPut]
        public HttpResponseMessage DeleteComment(CommentModel comment)
        {
            var res = CommentServices.Delete(comment.id);
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    message = "Your comment deleted Successfully"
                });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                message = "Something went Wrong"
            });
        }

        [Route("api/editcomment")]
        [HttpPut]
        public HttpResponseMessage EditComment(CommentModel commentModel)
        {
            var comment = CommentServices.Get(commentModel.id);
            comment.desc = commentModel.desc;
            var res = CommentServices.Update(comment);
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    message = "Your comment updated Successfully"
                });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                message = "Something went Wrong"
            });
        }
    }
}
