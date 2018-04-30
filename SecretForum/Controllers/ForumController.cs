using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SecretForum.Context;
using SecretForum.Models;
using System.Data.Entity;

namespace SecretForum.Controllers
{
    public class ForumController: ApiController
    {
        private ForumContext db = new ForumContext();

        [Route("stories")]
        [HttpGet]
        public IEnumerable<Story> GetAllStories()
        {
            return db.Stories.OrderBy(o => o.Headline).ToList();
        }

        [Route("stories/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetOneStory(int id)
        {
            var story = db.Stories.Include(i => i.Category).SingleOrDefault(s => s.ID == id);
            if (story == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(story);
            }
        } 
    }
}