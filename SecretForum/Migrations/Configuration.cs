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
            var firstAuthor = new Author
            {
                AuthorName = "Chuck",
            };
            context.Authors.AddOrUpdate(c => c.AuthorName, firstAuthor);
            context.SaveChanges();

            var newAuthor = new Author
            {
                AuthorName = "Jared",
            };
            context.Authors.AddOrUpdate(c => c.AuthorName, newAuthor);
            context.SaveChanges();

            var firstCategory = new Category
            {
                CategoryName = "Technology"
            };

            var FanFiction = new Category { CategoryName = "FanFiction" };
            var Food = new Category { CategoryName = "Food" };
            var Gardening = new Category { CategoryName = "Gardening" };


            var categories = new List<Category>
            {
                firstCategory,
                new Category { CategoryName = "Wellness"},
                new Category { CategoryName = "News"},
                FanFiction,
                Food,
                Gardening,

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
                new Story { Headline = "You won't believe what Harry Potter did to Malfoy", Body = "Hi Charley! Hi Wes!! :D", Category = FanFiction},
                new Story { Headline = "Jurassic Sea, the Orca's Fight Back", Body = "Thank you Jim for a great fanfiction headline lol", Category = FanFiction},
                new Story { Headline = "Han Solo is Back and He'll Make Your Castle Run", Body = "Woah, cool story bro", Category = FanFiction},
                new Story { Headline = "Daenerys and Cersei Shhhhh", Body = "dun dun dunna nun nun nunna nunna dunna nun na", Category = FanFiction},
                new Story { Headline = "Captain America and The Winter Soldier, the Hot and Steamy Behind the Scenes Romance", Body = "Bow chicka bow wow", Category = FanFiction},
                new Story { Headline = "Elevensies?!? Aragorn and the Four Hobbits", Body = "one ring to rule them all", Category = FanFiction},
                new Story { Headline = "Tasty Recipes", Body = "yum", Category = Food},
                new Story { Headline = "Grow the Best Tomatoes", Body = "Red and jouicy", Category = Gardening},
            };
            stories.ForEach(Story =>
            {
                context.Stories.AddOrUpdate(s => s.Headline, Story);
            });
            context.SaveChanges();
        }
    }
}
