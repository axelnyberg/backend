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
using Back_end.Models;
using System.Diagnostics;

namespace Back_end.Controllers
{
    public class PostsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Posts
        public IEnumerable<Post> GetPosts()
        {
            var posts = db.Posts
                .ToList();
            return posts;
        }

        // GET: api/Posts?MaxLat={MaxLat}&MinLat={MinLat}&MaxLong={MaxLong}&MinLong={MinLong}&DateTime={DateTime}
        public IEnumerable<Post> GetPosts(int MaxLat, int MinLat, int MaxLong, int MinLong, int DateTime)
        {
            var posts = db.Posts
                .Where(x => x.Latitude <= MaxLat && x.Latitude >= MinLat && x.Longitude <= MaxLong && x.Longitude >= MinLong)
                .ToList();
            return posts;
        }

        // GET: api/Post/User?UserID={UserID}
        [Route("api/Post/User")]
        public IEnumerable<Post> GetPosts(string UserID)
        {
            var posts = db.Posts.Where(c => c.ApplicationUserID == UserID)
                .ToList();
            return posts;
        }

        // GET: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult GetPost(int id)
        {
           
            Post post = db.Posts
                .Include(Post => Post.Comments)
                .Include(Post => Post.Reports)
                .SingleOrDefault(x => x.ID == id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/Posts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPost(int id, Post post)
        {
            
            //var p = modefier;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.ID)
            {
                return BadRequest();
            }

            db.Entry(post).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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

        // POST: api/Posts
        [ResponseType(typeof(Post))]
        public IHttpActionResult PostPost(Post post)
        {
            post.DateTime = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Posts.Add(post);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = post.ID }, post);
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
            return db.Posts.Count(e => e.ID == id) > 0;
        }
    }
}