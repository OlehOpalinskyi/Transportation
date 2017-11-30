namespace Transportation.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRoute : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Routes", "PointA");
            DropColumn("dbo.Routes", "PointB");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Routes", "PointB", c => c.String());
            AddColumn("dbo.Routes", "PointA", c => c.String());
        }
    }
}
