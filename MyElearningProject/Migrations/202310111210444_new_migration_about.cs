namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_migration_about : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AboutUs", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AboutUs", "ImageUrl");
        }
    }
}
