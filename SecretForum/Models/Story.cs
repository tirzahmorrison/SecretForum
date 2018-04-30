using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretForum.Models
{
    public class Story
    { 
        public int ID { get; set; }
        public string Headline { get; set; }
        public string Body { get; set; }

        public virtual int? AuthorId { get; set; }
        public Author Author { get; set; }

        public virtual int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}