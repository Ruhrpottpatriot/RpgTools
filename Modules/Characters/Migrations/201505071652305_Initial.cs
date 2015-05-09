namespace RpgTools.Characters.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Characters.CharacterDatabaseItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Culture = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Nickname = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Biography = c.String(),
                        Motto = c.String(),
                        Age = c.Int(nullable: false),
                        Portrait = c.Binary(),
                        OriginId = c.Guid(nullable: false),
                        ApprearanceId = c.Guid(nullable: false),
                        MetadataId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.Culture })
                .ForeignKey("Characters.Character_Appearance", t => t.ApprearanceId, cascadeDelete: true)
                .ForeignKey("Characters.Character_Metadata", t => t.MetadataId, cascadeDelete: true)
                .Index(t => t.ApprearanceId)
                .Index(t => t.MetadataId);
            
            CreateTable(
                "Characters.Character_Appearance",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Height = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        SkinColour = c.String(),
                        EyeColour = c.String(),
                        HeterochromiaIridum = c.Boolean(nullable: false),
                        HairColour = c.String(),
                        LipColour = c.String(),
                        Bust = c.Short(nullable: false),
                        Hip = c.Short(nullable: false),
                        Waist = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Characters.Character_Metadata",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Tags = c.String(),
                        VoiceActor = c.String(),
                        Occurrences = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Characters.CharacterDatabaseItems", "MetadataId", "Characters.Character_Metadata");
            DropForeignKey("Characters.CharacterDatabaseItems", "ApprearanceId", "Characters.Character_Appearance");
            DropIndex("Characters.CharacterDatabaseItems", new[] { "MetadataId" });
            DropIndex("Characters.CharacterDatabaseItems", new[] { "ApprearanceId" });
            DropTable("Characters.Character_Metadata");
            DropTable("Characters.Character_Appearance");
            DropTable("Characters.CharacterDatabaseItems");
        }
    }
}
