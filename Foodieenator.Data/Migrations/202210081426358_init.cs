namespace Foodieenator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiscountedFoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodId = c.Int(nullable: false),
                        DiscountedRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .Index(t => t.FoodId);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        FoodCategoryId = c.Int(nullable: false),
                        IsPublish = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodCategories", t => t.FoodCategoryId, cascadeDelete: true)
                .Index(t => t.FoodCategoryId);
            
            CreateTable(
                "dbo.FoodCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndexPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainImage = c.String(),
                        SliderText1 = c.String(),
                        SliderText2 = c.String(),
                        SliderText3 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Mail = c.String(),
                        PersonCount = c.Int(nullable: false),
                        ReservationDate = c.DateTime(nullable: false),
                        IsApprove = c.Boolean(nullable: false),
                        IsCancellationReservation = c.Boolean(nullable: false),
                        IsSeen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "FoodCategoryId", "dbo.FoodCategories");
            DropForeignKey("dbo.DiscountedFoods", "FoodId", "dbo.Foods");
            DropIndex("dbo.Foods", new[] { "FoodCategoryId" });
            DropIndex("dbo.DiscountedFoods", new[] { "FoodId" });
            DropTable("dbo.Reservations");
            DropTable("dbo.IndexPages");
            DropTable("dbo.FoodCategories");
            DropTable("dbo.Foods");
            DropTable("dbo.DiscountedFoods");
        }
    }
}
