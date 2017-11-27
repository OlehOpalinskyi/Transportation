namespace Transportation.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfBus = c.Int(nullable: false),
                        CountOfPassengers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PointA = c.String(),
                        PointB = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Points",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Point = c.String(),
                        Price = c.Double(nullable: false),
                        ArrivalTime = c.Time(nullable: false, precision: 7),
                        CityId = c.Int(nullable: false),
                        RouteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.RouteId);
            
            CreateTable(
                "dbo.TimeTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusId = c.Int(nullable: false),
                        RouteId = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Time = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bases", t => t.BusId, cascadeDelete: true)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .Index(t => t.BusId)
                .Index(t => t.RouteId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PointA = c.String(),
                        PointB = c.String(),
                        Price = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        TimeTableId = c.Int(nullable: false),
                        CustomerName = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TimeTable", t => t.TimeTableId, cascadeDelete: true)
                .Index(t => t.TimeTableId);
            
            CreateTable(
                "dbo.RouteDataModelBusDataModels",
                c => new
                    {
                        RouteDataModel_Id = c.Int(nullable: false),
                        BusDataModel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RouteDataModel_Id, t.BusDataModel_Id })
                .ForeignKey("dbo.Routes", t => t.RouteDataModel_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bases", t => t.BusDataModel_Id, cascadeDelete: true)
                .Index(t => t.RouteDataModel_Id)
                .Index(t => t.BusDataModel_Id);
            
            CreateTable(
                "dbo.CityDataModelRouteDataModels",
                c => new
                    {
                        CityDataModel_Id = c.Int(nullable: false),
                        RouteDataModel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CityDataModel_Id, t.RouteDataModel_Id })
                .ForeignKey("dbo.Cities", t => t.CityDataModel_Id, cascadeDelete: true)
                .ForeignKey("dbo.Routes", t => t.RouteDataModel_Id, cascadeDelete: true)
                .Index(t => t.CityDataModel_Id)
                .Index(t => t.RouteDataModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "TimeTableId", "dbo.TimeTable");
            DropForeignKey("dbo.TimeTable", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.TimeTable", "BusId", "dbo.Bases");
            DropForeignKey("dbo.CityDataModelRouteDataModels", "RouteDataModel_Id", "dbo.Routes");
            DropForeignKey("dbo.CityDataModelRouteDataModels", "CityDataModel_Id", "dbo.Cities");
            DropForeignKey("dbo.Points", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.Points", "CityId", "dbo.Cities");
            DropForeignKey("dbo.RouteDataModelBusDataModels", "BusDataModel_Id", "dbo.Bases");
            DropForeignKey("dbo.RouteDataModelBusDataModels", "RouteDataModel_Id", "dbo.Routes");
            DropIndex("dbo.CityDataModelRouteDataModels", new[] { "RouteDataModel_Id" });
            DropIndex("dbo.CityDataModelRouteDataModels", new[] { "CityDataModel_Id" });
            DropIndex("dbo.RouteDataModelBusDataModels", new[] { "BusDataModel_Id" });
            DropIndex("dbo.RouteDataModelBusDataModels", new[] { "RouteDataModel_Id" });
            DropIndex("dbo.Orders", new[] { "TimeTableId" });
            DropIndex("dbo.TimeTable", new[] { "RouteId" });
            DropIndex("dbo.TimeTable", new[] { "BusId" });
            DropIndex("dbo.Points", new[] { "RouteId" });
            DropIndex("dbo.Points", new[] { "CityId" });
            DropTable("dbo.CityDataModelRouteDataModels");
            DropTable("dbo.RouteDataModelBusDataModels");
            DropTable("dbo.Orders");
            DropTable("dbo.TimeTable");
            DropTable("dbo.Points");
            DropTable("dbo.Cities");
            DropTable("dbo.Routes");
            DropTable("dbo.Bases");
        }
    }
}
