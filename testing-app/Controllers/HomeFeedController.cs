using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testing_app.Data;
using testing_app.Factory;
using testing_app.Infrastructure;
using testing_app.Models;

namespace testing_app.Controllers
{
    public class HomeFeedController : ApiController
    {
        private testing_appContext _db;
        public HomeFeedController(IAppDatabase appDatabase)
        {
            _db = appDatabase.Db;
        }

        [HttpGet]

        public IHttpActionResult NewsFeed(int page)
        {
            var response = _db.Users.OrderBy(u=>u.Id).Skip(page * 5).Take(5);
            return Ok(response);

        }
    }
}
