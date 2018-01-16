namespace Transportation.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCitiesFromRoute : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CityDataModelRouteDataModels", "CityDataModel_Id", "dbo.Cities");
            DropForeignKey("dbo.CityDataModelRouteDataModels", "RouteDataModel_Id", "dbo.Routes");
            DropIndex("dbo.CityDataModelRouteDataModels", new[] { "CityDataModel_Id" });
            DropIndex("dbo.CityDataModelRouteDataModels", new[] { "RouteDataModel_Id" });
            AddColumn("dbo.Routes", "NameRoute", c => c.String());
            DropTable("dbo.CityDataModelRouteDataModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CityDataModelRouteDataModels",
                c => new
                    {
                        CityDataModel_Id = c.Int(nullable: false),
                        RouteDataModel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CityDataModel_Id, t.RouteDataModel_Id });
            
            DropColumn("dbo.Routes", "NameRoute");
            CreateIndex("dbo.CityDataModelRouteDataModels", "RouteDataModel_Id");
            CreateIndex("dbo.CityDataModelRouteDataModels", "CityDataModel_Id");
            AddForeignKey("dbo.CityDataModelRouteDataModels", "RouteDataModel_Id", "dbo.Routes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CityDataModelRouteDataModels", "CityDataModel_Id", "dbo.Cities", "Id", cascadeDelete: true);
        }
    }
}
