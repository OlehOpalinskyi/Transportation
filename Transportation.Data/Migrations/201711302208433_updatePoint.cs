namespace Transportation.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePoint : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Points", "Point");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Points", "Point", c => c.String());
        }
    }
}
