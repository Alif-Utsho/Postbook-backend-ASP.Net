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
    public class ReactController : ApiController
    {
        [Route("api/reacts/{post_id}")]
        [HttpGet]
        public HttpResponseMessage Reacts(int post_id)
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            var reacts = ReactServices.GetByPostID(post_id);
            var reactDetails = new List<Object>();
            foreach(var react in reacts)
            {
                var user = UserServices.Get(react.user_id);
                reactDetails.Add(new
                {
                    react.id,
                    react.user_id,
                    react.post_id,
                    user = user
                });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                reacts = reactDetails,
                authId = token.user_id
            });
        }

        [Route("api/like")]
        [HttpPost]
        public HttpResponseMessage Like(ReactModel react)
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            react.user_id = token.user_id;
            var res = ReactServices.Add(react);
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    message = "You loved the post"
                });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                message = "Something went wrong"
            });
        }

        [Route("api/unlike")]
        [HttpPut]
        public HttpResponseMessage Unlike(ReactModel reactModel)
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            var res = ReactServices.DeleteByUserPostID(token.user_id, reactModel.post_id);
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    message = "You loved the post"
                });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                message = "Something went wrong"
            });
        }
    }
}
