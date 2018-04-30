using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SecretForum.Models;

namespace SecretForum.Context
{
    public class ForumContext:DbContext
    {
            public DbSet<Category> Categories { get; set; }
            public DbSet<Story>Stories { get; set; }
            public DbSet<Author> Authors { get; set; }
    }
}
