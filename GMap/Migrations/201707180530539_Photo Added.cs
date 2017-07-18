namespace GMap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Photo");
        }
    }
}
