namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_migration_courseregister : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseRegisters",
                c => new
                    {
                        CourseRegisterID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CourseRegister_CourseRegisterID = c.Int(),
                    })
                .PrimaryKey(t => t.CourseRegisterID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.CourseRegisters", t => t.CourseRegister_CourseRegisterID)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID)
                .Index(t => t.CourseRegister_CourseRegisterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseRegisters", "StudentID", "dbo.Students");
            DropForeignKey("dbo.CourseRegisters", "CourseRegister_CourseRegisterID", "dbo.CourseRegisters");
            DropForeignKey("dbo.CourseRegisters", "CourseID", "dbo.Courses");
            DropIndex("dbo.CourseRegisters", new[] { "CourseRegister_CourseRegisterID" });
            DropIndex("dbo.CourseRegisters", new[] { "CourseID" });
            DropIndex("dbo.CourseRegisters", new[] { "StudentID" });
            DropTable("dbo.CourseRegisters");
        }
    }
}
