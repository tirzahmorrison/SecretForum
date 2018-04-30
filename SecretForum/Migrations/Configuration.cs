namespace SecretForum.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SecretForum.Models;
    using System.Collections.Generic;   

    internal sealed class Configuration : DbMigrationsConfiguration<SecretForum.Context.ForumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SecretForum.Context.ForumContext context)
        {
            var newAuthor = new Author
            {
                AuthorName = "Chuck",
            };
            context.Authors.AddOrUpdate(c => c.AuthorName, newAuthor);
            context.SaveChanges();

            var firstCategory = new Category
            {
                CategoryName = "Technology"
            };
            var categories = new List<Category>
            {
                firstCategory,
                new Category { CategoryName = "Wellness"},
                new Category { CategoryName = "News"},

            };
            categories.ForEach(Category =>
            {
             context.Categories.AddOrUpdate(c => c.CategoryName, Category);
            });
            context.SaveChanges();

           
            var firstStory = new Story
            {
                Headline = "Uh Oh",
                Body = "Look at all this shit in here!",

            };
            var stories = new List<Story>
            {
                firstStory,
                new Story { Headline = "Look What's Happening", Body = "Woah, cool story bro" }
            };
            stories.ForEach(Story =>
            {
                context.Stories.AddOrUpdate(s => s.Headline, Story);
            });
            context.SaveChanges();
        }
    }
}
