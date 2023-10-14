namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_service : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Icon = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ServiceID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Services");
        }
    }
}
