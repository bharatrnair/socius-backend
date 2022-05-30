using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using testing_app.Data;
using testing_app.Infrastructure;
using testing_app.Models;

namespace testing_app.Controllers
{
    [Authenticate]
    public class PostsController : ApiController
    {
        private testing_appContext db = new testing_appContext();

        // GET: api/Posts
        public IQueryable<Post> GetPosts()
        {
            return db.Posts;
        }

        // GET: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult GetPost(int id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/Posts/5
       

        // POST: api/Posts
        [ResponseType(typeof(Post))]
        public IHttpActionResult PostPost(PostValidation postInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Post post = Mapper.Map<Post>(postInput);
            var Session = HttpContext.Current.Session;

            post.UsersId = (int)Session["id"];

            post.Time = DateTime.Now;

            db.Posts.Add(post);
            db.SaveChanges();

            return Created("post",post);
        }

        // DELETE: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult DeletePost(int id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            db.Posts.Remove(post);
            db.SaveChanges();

            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int id)
        {
            return db.Posts.Count(e => e.Id == id) > 0;
        }
    }
}