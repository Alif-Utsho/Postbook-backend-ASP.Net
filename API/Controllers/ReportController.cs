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
    public class ReportController : ApiController
    {
        [Route("api/reports")]
        [HttpGet]
        public HttpResponseMessage Reports()
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            var reports = ReportServices.Get();
            var reportDetails = new List<Object>();
            foreach (var report in reports)
            {
                var user = UserServices.Get(report.user_id);
                var post = PostServices.Get(report.post_id);
                reportDetails.Add(new
                {
                    report.id,
                    report.user_id,
                    report.post_id,
                    report.desc,
                    user = user,
                    post = post
                });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                reports = reportDetails
                //authId = token.user_id
            });
        }

        [Route("api/createreport")]
        [HttpPost]
        public HttpResponseMessage CreateReport(ReportModel report)
        {
            var token = TokenServices.Get(Request.Headers.GetValues("token").First());
            report.created_at = System.DateTime.Now;
            report.user_id = token.user_id;
            var res = ReportServices.Add(report);
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    message = "Report submitted successfully"
                });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                message = "Something went wrong"
            });
        }
    }
}
