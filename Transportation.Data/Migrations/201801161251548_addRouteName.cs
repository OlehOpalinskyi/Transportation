namespace Transportation.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRouteName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routes", "RouteName", c => c.String());
            DropColumn("dbo.Routes", "NameRoute");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Routes", "NameRoute", c => c.String());
            DropColumn("dbo.Routes", "RouteName");
        }
    }
}
