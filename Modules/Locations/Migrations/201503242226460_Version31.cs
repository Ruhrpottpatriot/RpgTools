namespace RpgTools.Locations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version31 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Locations.Localisations",
                c => new
                    {
                        EntryId = c.Guid(nullable: false),
                        Culture = c.String(),
                    })
                .PrimaryKey(t => t.EntryId)
                .ForeignKey("Locations.Locations", t => t.EntryId)
                .Index(t => t.EntryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Locations.Localisations", "EntryId", "Locations.Locations");
            DropIndex("Locations.Localisations", new[] { "EntryId" });
            DropTable("Locations.Localisations");
        }
    }
}
