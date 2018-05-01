using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretForum.ViewModels
{
    public class CreateStoryViewModel
    {
        public string Category { get; set; }
        public string Author { get; set; }
        public string Headline { get; set; }
        public string Body { get; set; }
    }
}