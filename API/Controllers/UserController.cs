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
    public class UserController : ApiController
    {
        [Route("api/user/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var user = UserServices.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Route("api/users")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            var userList = UserServices.Get();
            var userDetailsList = new List<Object>();
            foreach(var user in userList)
            {
                if (user.id == token.user_id) continue;
                var profile = ProfileServices.Get(user.id);
                var send_byfriends = ConnectionServices.SentByFriends(user.id);
                var rec_byfriends = ConnectionServices.RecByFriends(user.id);
                var requests = ConnectionServices.GetRequests(user.id);
                var sents = ConnectionServices.GetSents(user.id);
                userDetailsList.Add(new
                {
                    user.id, user.name, user.phone, user.email, user.type,
                    profile = profile,
                    send_byfriends = send_byfriends,
                    rec_byfriends = rec_byfriends,
                    request = requests,
                    sent = sents,
                });
            }
            

            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                users = userDetailsList,
                authId = token.user_id
            });
        }

        [Route("api/users/find")]
        [HttpGet]
        public HttpResponseMessage GetUser()
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            var userList = UserServices.Get();
            var userDetailsList = new List<Object>();
            foreach (var user in userList)
            {
                if (user.id == token.user_id || user.type.Equals("admin")) continue;
                var profile = ProfileServices.Get(user.id);
                var send_byfriends = ConnectionServices.SentByFriends(user.id);
                var rec_byfriends = ConnectionServices.RecByFriends(user.id);
                var requests = ConnectionServices.GetRequests(user.id);
                var sents = ConnectionServices.GetSents(user.id);
                var reqList = new List<ConnectionModel>();
                foreach(var request in requests)
                {
                    var req = new ConnectionModel()
                    {
                        id = request.id,
                        receiver = request.receiver.id,
                        sender = request.sender.id,
                        status = request.status,
                    };
                    reqList.Add(req);
                }
                var sentList = new List<ConnectionModel>();
                foreach(var sent in sents)
                {
                    var s = new ConnectionModel()
                    {
                        id = sent.id,
                        receiver = sent.receiver.id,
                        sender = sent.sender.id,
                        status = sent.status
                    };
                    sentList.Add(s);
                }
                userDetailsList.Add(new
                {
                    user.id,
                    user.name,
                    user.phone,
                    user.email,
                    user.type,
                    profile = profile,
                    send_byfriends = send_byfriends,
                    rec_byfriends = rec_byfriends,
                    request = reqList,
                    sent = sentList,
                });
            }


            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                users = userDetailsList,
                authId = token.user_id
            });
        }

        [Route("api/userupdate")]
        [HttpPut]
        public HttpResponseMessage Update(UserModel user)
        {
            var res = UserServices.Update(user);
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                res,
                message = new { message = "User updated" }
            });
        }

        [Route("api/userdelete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var res = UserServices.Delete(id);
            return Request.CreateResponse(HttpStatusCode.Accepted, new
            {
                res,
                message = "User deleted"
            });
        }

        [Route("api/username")]
        [HttpGet]
        public HttpResponseMessage GetUsername()
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            if (token.expired) return null;
            var user = UserServices.Get(token.user_id);
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                user = user
            });
        }

        [Route("api/profile")]
        [HttpGet]
        public HttpResponseMessage Profile()
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            var user = UserServices.Get(token.user_id);
            var profile = ProfileServices.Get(token.user_id);
            var send_byfriends = ConnectionServices.SentByFriends(token.user_id);
            var rec_byfriends = ConnectionServices.RecByFriends(token.user_id);
            var requests = ConnectionServices.GetRequests(token.user_id);
            var sents = ConnectionServices.GetSents(token.user_id);
            var posts = PostServices.GetPostOfUser(token.user_id);

            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                user = new
                {
                    user.id, user.name, user.phone, user.email, user.type,
                    profile = profile,
                    send_byfriends = send_byfriends,
                    rec_byfriends = rec_byfriends,
                    request = requests,
                    sent = sents,
                    posts = posts
                }
            });
        }

        [Route("api/profile/{id}")]
        [HttpGet]
        public HttpResponseMessage SingleUser(int id)
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            var user = UserServices.Get(id);
            var profile = ProfileServices.Get(id);
            var send_byfriends = ConnectionServices.SentByFriends(id);
            var rec_byfriends = ConnectionServices.RecByFriends(id);
            var requests = ConnectionServices.GetRequests(id);
            var sents = ConnectionServices.GetSents(id);
            var posts = PostServices.GetPostOfUser(id);

            var reqList = new List<ConnectionModel>();
            foreach (var request in requests)
            {
                var req = new ConnectionModel()
                {
                    id = request.id,
                    receiver = request.receiver.id,
                    sender = request.sender.id,
                    status = request.status,
                };
                reqList.Add(req);
            }
            var sentList = new List<ConnectionModel>();
            foreach (var sent in sents)
            {
                var s = new ConnectionModel()
                {
                    id = sent.id,
                    receiver = sent.receiver.id,
                    sender = sent.sender.id,
                    status = sent.status
                };
                sentList.Add(s);
            }

            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                user = new
                {
                    user.id, user.name, user.phone, user.email, user.type,
                    profile = profile,
                    send_byfriends = send_byfriends,
                    rec_byfriends = rec_byfriends,
                    request = reqList,
                    sent = sentList,
                    posts = posts
                },
                authId = token.user_id
            });
        }

        [Route("api/editprofile")]
        [HttpPut]
        public HttpResponseMessage EditProfile(UserProfileModel userProfile)
        {
            var user = UserServices.Get(userProfile.id);
            user.name = userProfile.name;
            var res = UserServices.Update(user);
            var profile = ProfileServices.Get(userProfile.id);
            profile.bio = userProfile.bio;
            profile.linkedin = userProfile.linkedin;
            profile.instagram = userProfile.instagram;
            profile.github = userProfile.github;
            var res_pro = ProfileServices.Update(profile);
            if(res && res_pro)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    message = "Profile updated"
                });
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                message = "Something went wrong"
            });
        }
    }
}
