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
    public class ForumController : ApiController
    {
        private ForumContext db = new ForumContext();

        [Route("api/stories")]
        [HttpGet]
        public IHttpActionResult GetAllStories([FromUri]string category = null, [FromUri]int? count = null)
        {
            var query = db.Stories.Include(s => s.Category);
            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(s => s.Category.CategoryName == category);
            }
            if (count != null && count > 0)
            {
                query = query
                    .OrderByDescending(s => s.ID)
                    .Take((int)count);
            }
            return Ok(query.ToList());
        }

        [Route("api/story/{id:int}")]
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

        [Route("api/story")]
        [HttpPost]
        public IHttpActionResult AddOneStory([FromBody]ViewModels.CreateStoryViewModel createStory)
        {
            var category = db.Categories.SingleOrDefault(s => s.CategoryName == createStory.Category);
            if (category == null)
            {
                return BadRequest();
            }

            Author author = null;
            if (!string.IsNullOrWhiteSpace(createStory.Author))
            {
                author = db.Authors.SingleOrDefault(s => s.AuthorName == createStory.Author);
                if (author == null)
                {
                    author = db.Authors.Add(new Author { AuthorName = createStory.Author });
                    db.SaveChanges();
                }
            }
            var story = db.Stories.Add(new Story
            {
                Author = author,
                Category = category,
                Headline = createStory.Headline,
                Body = createStory.Body
            });
            db.SaveChanges();
            return Ok(story.ID);
        }

        [Route("api/story/{id:int}")]
        [HttpDelete]
        public IHttpActionResult DeleteOneStory(int id)
        {
            var story = db.Stories.SingleOrDefault(s => s.ID == id);
            if (story == null)
            {
                return NotFound();
            }
            else
            {
                db.Stories.Remove(story);
                db.SaveChanges();
                return Ok();
            }
        }

        [Route("api/categories")]
        [HttpGet]
        public IHttpActionResult GetAllCategories()
        {
            return Ok(db.Categories.ToList());
        }
    }
}