using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace testing_app.Controllers
{
    public class LogoutController : ApiController
    {
        [HttpPost]

        public IHttpActionResult Logout()
        {
            var Session = System.Web.HttpContext.Current.Session;
            Session.Abandon();
            Session.Clear();
           return  Ok(new { });
        }
    }
}
