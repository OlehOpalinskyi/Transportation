namespace Transportation.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOrder1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "PointA", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "PointB", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "PointB", c => c.String());
            AlterColumn("dbo.Orders", "PointA", c => c.String());
        }
    }
}
