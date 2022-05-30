using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using testing_app.Data;
using testing_app.Models;
using AutoMapper;

namespace testing_app.Controllers
{
    public class UsersController : ApiController
    {
        private testing_appContext db = new testing_appContext();

        // POST: api/Users
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Signup Signup)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Users users = Mapper.Map<Users>(Signup);

            users.password = BCrypt.Net.BCrypt.HashPassword(users.password);
            db.Users.Add(users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users.Id }, users);
        }

    }
}