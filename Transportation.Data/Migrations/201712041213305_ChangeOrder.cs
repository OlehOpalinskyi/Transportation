namespace Transportation.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Pay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Pay");
        }
    }
}
