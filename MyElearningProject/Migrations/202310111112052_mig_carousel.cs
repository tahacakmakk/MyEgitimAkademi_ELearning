namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_carousel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carousels",
                c => new
                    {
                        CarouselID = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Title = c.String(),
                        Title2 = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CarouselID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Carousels");
        }
    }
}
