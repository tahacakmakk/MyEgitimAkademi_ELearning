namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_aboutus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutUs",
                c => new
                    {
                        AboutUSID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AboutUSID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AboutUs");
        }
    }
}
