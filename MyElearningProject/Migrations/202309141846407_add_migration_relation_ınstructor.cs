namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_migration_relation_ınstructor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "InstructorID", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "InstructorID");
            AddForeignKey("dbo.Courses", "InstructorID", "dbo.Instructors", "InstructorID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "InstructorID", "dbo.Instructors");
            DropIndex("dbo.Courses", new[] { "InstructorID" });
            DropColumn("dbo.Courses", "InstructorID");
        }
    }
}
