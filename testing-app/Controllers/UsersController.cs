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
            return Ok(user) ; 
        }

        
        

        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsersByPhone(long phone)
        {
            IQueryable<Users> users = db.Users.Where(user => user.phone == phone);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers(int id, Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.Id)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }




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

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
       
    }


}