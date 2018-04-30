namespace SecretForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedStuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Categories = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Headline = c.String(),
                        Body = c.String(),
                        AuthorId = c.Int(),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.AuthorId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Stories", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Stories", new[] { "CategoryId" });
            DropIndex("dbo.Stories", new[] { "AuthorId" });
            DropTable("dbo.Stories");
            DropTable("dbo.Categories");
            DropTable("dbo.Authors");
        }
    }
}
