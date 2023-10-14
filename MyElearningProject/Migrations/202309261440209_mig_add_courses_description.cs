namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_courses_description : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Description");
        }
    }
}
