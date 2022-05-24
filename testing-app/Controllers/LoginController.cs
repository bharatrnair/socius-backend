using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testing_app.Data;
using testing_app.Factory;
using testing_app.Models;

namespace testing_app.Controllers
{
    public class LoginController : ApiController
    {
        private testing_appContext db;
        public LoginController(IAppDatabase appDatabase)
        {
            db = appDatabase.Db;
        }
       
        [HttpPost]
        public IHttpActionResult Login(SignInCredentials signInCredentials)
        {
            Users credentials = db.Users.SingleOrDefault(user => user.Email == signInCredentials.Email);
            if(credentials == null)
            {
                return NotFound();
            }
            else if (BCrypt.Net.BCrypt.Verify(signInCredentials.password, credentials.password))
            {

                var Session = System.Web.HttpContext.Current.Session;
                Session["id"] = credentials.Id;
               
               

                return Ok(new {status = true, message = "success" });
            }
            return BadRequest();

        }
    }
}
