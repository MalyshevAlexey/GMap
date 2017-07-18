namespace GMap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumberAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Nr", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Nr");
        }
    }
}
