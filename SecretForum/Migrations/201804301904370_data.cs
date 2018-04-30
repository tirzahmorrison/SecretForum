namespace SecretForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryName", c => c.String());
            DropColumn("dbo.Categories", "Categories");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Categories", c => c.Int(nullable: false));
            DropColumn("dbo.Categories", "CategoryName");
        }
    }
}
