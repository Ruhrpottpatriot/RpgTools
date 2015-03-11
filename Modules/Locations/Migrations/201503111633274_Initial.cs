namespace RpgTools.Locations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Locations.Locations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Coordinates = c.Geography(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Locations.CityDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Planet = c.Guid(nullable: false),
                        IsCapital = c.Boolean(),
                        Population = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Locations.Locations", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "Locations.PlanetDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        System = c.Guid(nullable: false),
                        Population = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Locations.Locations", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "Locations.SystemDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Sector = c.Guid(nullable: false),
                        Population = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Locations.Locations", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "Locations.SectorDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Population = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Locations.Locations", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Locations.SectorDetails", "Id", "Locations.Locations");
            DropForeignKey("Locations.SystemDetails", "Id", "Locations.Locations");
            DropForeignKey("Locations.PlanetDetails", "Id", "Locations.Locations");
            DropForeignKey("Locations.CityDetails", "Id", "Locations.Locations");
            DropIndex("Locations.SectorDetails", new[] { "Id" });
            DropIndex("Locations.SystemDetails", new[] { "Id" });
            DropIndex("Locations.PlanetDetails", new[] { "Id" });
            DropIndex("Locations.CityDetails", new[] { "Id" });
            DropTable("Locations.SectorDetails");
            DropTable("Locations.SystemDetails");
            DropTable("Locations.PlanetDetails");
            DropTable("Locations.CityDetails");
            DropTable("Locations.Locations");
        }
    }
}
