namespace RpgTools.Characters.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0_1_0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Characters.Characters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Nickname = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Biography = c.String(),
                        Motto = c.String(),
                        Age = c.Int(nullable: false),
                        PortraitsId = c.Guid(nullable: false),
                        MetadataId = c.Guid(nullable: false),
                        AppearanceId = c.Guid(nullable: false),
                        OriginId = c.Guid(nullable: false),
                        Portrait_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Characters.Appearances", t => t.AppearanceId, cascadeDelete: true)
                .ForeignKey("Characters.Metadata", t => t.MetadataId, cascadeDelete: true)
                .ForeignKey("Characters.Portraits", t => t.Portrait_Id)
                .Index(t => t.MetadataId)
                .Index(t => t.AppearanceId)
                .Index(t => t.Portrait_Id);
            
            CreateTable(
                "Characters.Appearances",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Gender = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        SkinColour = c.String(),
                        EyeColour = c.String(),
                        SpecialFeatures = c.String(),
                        HairColour = c.String(),
                        LipColour = c.String(),
                        Bust = c.Short(nullable: false),
                        Hip = c.Short(nullable: false),
                        Waist = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Characters.Metadata",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Tags = c.String(),
                        VoiceActor = c.String(),
                        Occurrences = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Characters.Portraits",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Characters.Characters", "Portrait_Id", "Characters.Portraits");
            DropForeignKey("Characters.Characters", "MetadataId", "Characters.Metadata");
            DropForeignKey("Characters.Characters", "AppearanceId", "Characters.Appearances");
            DropIndex("Characters.Characters", new[] { "Portrait_Id" });
            DropIndex("Characters.Characters", new[] { "AppearanceId" });
            DropIndex("Characters.Characters", new[] { "MetadataId" });
            DropTable("Characters.Portraits");
            DropTable("Characters.Metadata");
            DropTable("Characters.Appearances");
            DropTable("Characters.Characters");
        }
    }
}
