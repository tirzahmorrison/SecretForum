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
        public IHttpActionResult GetAllStories([FromUri]string category, [FromUri]int? count)
        {
            var query = db.Stories.Include(s => s.Category);
            if (string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(s => s.Category.CategoryName == category);
            }
            if (count != null && count > 0) 
            {
                query = query
                    .OrderByDescending(s =>> s.ID)
                    .Take(count);
            }
            return Ok(query.ToList());
        }

        [Route("story/{id:int}")]
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

        public IHttpActionResult GetAllCategories()
        {
            return Ok(db.Categories.ToList());
        }
    }
}