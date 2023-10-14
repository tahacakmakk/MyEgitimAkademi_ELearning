namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_category_ımageurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ImgeUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "ImgeUrl");
        }
    }
}
