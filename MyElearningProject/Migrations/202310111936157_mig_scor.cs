namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_scor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseScors",
                c => new
                    {
                        CourseScorID = c.Int(nullable: false, identity: true),
                        ScorValue = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseScorID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseScors", "StudentID", "dbo.Students");
            DropForeignKey("dbo.CourseScors", "CourseID", "dbo.Courses");
            DropIndex("dbo.CourseScors", new[] { "StudentID" });
            DropIndex("dbo.CourseScors", new[] { "CourseID" });
            DropTable("dbo.CourseScors");
        }
    }
}
