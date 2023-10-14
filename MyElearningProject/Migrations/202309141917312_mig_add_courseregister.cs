namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_courseregister : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseRegisters", "CourseRegister_CourseRegisterID", "dbo.CourseRegisters");
            DropIndex("dbo.CourseRegisters", new[] { "CourseRegister_CourseRegisterID" });
            DropColumn("dbo.CourseRegisters", "CourseRegister_CourseRegisterID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseRegisters", "CourseRegister_CourseRegisterID", c => c.Int());
            CreateIndex("dbo.CourseRegisters", "CourseRegister_CourseRegisterID");
            AddForeignKey("dbo.CourseRegisters", "CourseRegister_CourseRegisterID", "dbo.CourseRegisters", "CourseRegisterID");
        }
    }
}
