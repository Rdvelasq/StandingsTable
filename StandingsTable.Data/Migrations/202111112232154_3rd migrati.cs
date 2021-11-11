namespace StandingsTable.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3rdmigrati : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Goals = c.Int(),
                        Assist = c.Int(),
                        TeamId = c.Int(),
                        IsFieldPlayer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .Index(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "TeamId" });
            DropTable("dbo.Players");
        }
    }
}
