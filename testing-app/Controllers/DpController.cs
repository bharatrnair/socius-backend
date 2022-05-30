using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using testing_app.Models;
using testing_app.Data;
using testing_app.Factory;
using testing_app.Infrastructure;

namespace testing_app.Controllers
{
    [Authenticate]
    public class DpController : ApiController
    {
        private IAppDatabase _appDatabase;

        public DpController(IAppDatabase appDatabase)
        {
            _appDatabase = appDatabase;
        }
        [HttpPost]
        public IHttpActionResult Post(DpUrl dpUrl )
        {
            var Sesion = HttpContext.Current.Session;
            Users currentUser = _appDatabase.Db.Users.Find(Sesion["id"]);

            currentUser.DpUrl = dpUrl.Url;
            _appDatabase.Db.SaveChanges();
            return Ok(currentUser);
        }
    }
}
