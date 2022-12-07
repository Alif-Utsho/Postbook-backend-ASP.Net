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
    public class ConnectionController : ApiController
    {
        [Route("api/connection")]
        [HttpGet]
        public HttpResponseMessage Connections()
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            var requests = ConnectionServices.GetRequests(token.user_id);
            var sents = ConnectionServices.GetSents(token.user_id);
            var friends = ConnectionServices.GetFriends(token.user_id);
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                request = requests,
                sent = sents,
                friends = friends,
                authId = token.user_id
            });
        }

        [Route("api/addfriend")]
        [HttpPost]
        public HttpResponseMessage AddFriend(ConnectionModel connectionModel)
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            connectionModel.sender = token.user_id;
            connectionModel.status = "follower";
            var res = ConnectionServices.Add(connectionModel);
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    status = 200,
                    message = "Request sent"
                });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                message = "Something went wrong"
            });
        }

        [Route("api/cancelrequest")]
        [HttpPut]
        public HttpResponseMessage CancelReq(ConnectionModel connectionModel)
        {
            var res = ConnectionServices.Delete(connectionModel.id);
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    status = 200,
                    message = "Request cancelled"
                });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                message = "Something went wrong"
            });
        }

        [Route("api/confirmrequest")]
        [HttpPut]
        public HttpResponseMessage ConfirmReq(ConnectionModel connectionModel)
        {
            var connection = ConnectionServices.Get(connectionModel.id);
            connection.status = "friend";
            var res = ConnectionServices.Update(connection);
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    status = 200,
                    message = "Request confirmed"
                });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                message = "Something went wrong"
            });
        }

        [Route("api/unfriend")]
        [HttpPut]
        public HttpResponseMessage Unfriend(ConnectionModel connectionModel)
        {
            var res = ConnectionServices.Delete(connectionModel.id);
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    status = 200,
                    message = "Unfriended"
                });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                message = "Something went wrong"
            });
        }
    }
}
