namespace GMap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Lat = c.String(),
                        Lng = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Formulists");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Formulists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nickname = c.String(),
                        Number = c.String(),
                        Address = c.String(),
                        Lat = c.String(),
                        Lng = c.String(),
                        photo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Users");
        }
    }
}
