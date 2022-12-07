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
    public class AuthController : ApiController
    {
        
        [Route("api/registration")]
        [HttpPost]
        public HttpResponseMessage Registration(UserModel user)
        {
            var res = UserServices.Registration(user);
            if (res == null)
            {
                return Request.CreateResponse(HttpStatusCode.Created, new
                {
                    message = "Something went wrong"
                });
            }
            var profileModel = new ProfileModel()
            {
                user_id = res.id
            };
            ProfileServices.Add(profileModel);
            var token = new TokenModel()
            {
                user_id = res.id,
                type = res.type,
                token1 = new Random().Next().ToString(),
                expired = false
            };
            TokenServices.Add(token);
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                message =  "User registered",
                token = token
            });
        }

        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(UserModel user)
        {
            var res = UserServices.Login(user);
            if (res == null)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new
                {
                    message = "Invalid Credential"
                });
            }
            var token = new TokenModel()
            {
                user_id = res.id,
                type = res.type,
                token1 = new Random().Next().ToString(),
                expired = false
            };
            TokenServices.Add(token);
            return Request.CreateResponse(HttpStatusCode.Created, new
            {
                status = 200,
                user = res,
                token = token
            });
        }

        [Route("api/signout")]
        [HttpPut]
        public HttpResponseMessage Signout()
        {
            var tokenStr = Request.Headers.GetValues("token").First();
            var token = TokenServices.Get(tokenStr);
            var tm = new TokenModel()
            {
                id = token.id,
                user_id = token.user_id,
                type = token.type,
                token1 = token.token1,
                expired = true
            };
            TokenServices.Update(tm);
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                message = "User signed out"
            });
        }

        [Route("api/countAll")]
        [HttpGet]
        public HttpResponseMessage CountAll()
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            var posts = PostServices.Get().Count();
            var users = UserServices.Get().Count();
            var comments = CommentServices.Get().Count();
            var reacts = ReactServices.Get().Count();
            var reports = ReportServices.Get().Count();

            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                posts,
                users,
                comments,
                reacts,
                reports
            });
        }
        
    }
}
