using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using testing_app.Data;
using testing_app.Infrastructure;
using testing_app.Models;

namespace testing_app.Controllers
{
    [Authenticate]
    public class GetUsersController : ApiController
    {
        private testing_appContext db = new testing_appContext();

        // GET: api/Users
        [ResponseType(typeof(Users))]
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            var Session = System.Web.HttpContext.Current.Session;
            if (Session["Id"] == null)
            {
                return NotFound();
            }

            Users user = db.Users.Find(Session["Id"]);
            return Ok(user);
        }
    }
}
