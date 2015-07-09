namespace RpgTools.Characters.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Characters.Character_Appearance", newName: "AppearanceItems");
            RenameTable(name: "Characters.Character_Metadata", newName: "Metadata");
            DropForeignKey("Characters.CharacterDatabaseItems", "AppearanceId", "Characters.Character_Appearance");
            DropForeignKey("Characters.CharacterDatabaseItems", "MetadataId", "Characters.Character_Metadata");
            DropIndex("Characters.CharacterDatabaseItems", new[] { "AppearanceId" });
            DropIndex("Characters.CharacterDatabaseItems", new[] { "MetadataId" });
            CreateTable(
                "Characters.CharacterItems",
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
                        PortraitId = c.Guid(nullable: false),
                        MetadataId = c.Guid(nullable: false),
                        AppearanceId = c.Guid(nullable: false),
                        OriginId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Characters.AppearanceItems", t => t.AppearanceId, cascadeDelete: true)
                .ForeignKey("Characters.Metadata", t => t.MetadataId, cascadeDelete: true)
                .ForeignKey("Characters.Portraits", t => t.PortraitId, cascadeDelete: true)
                .Index(t => t.PortraitId)
                .Index(t => t.MetadataId)
                .Index(t => t.AppearanceId);
            
            CreateTable(
                "Characters.Portraits",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("Characters.AppearanceItems", "SpecialFeatures", c => c.String());
            DropColumn("Characters.AppearanceItems", "HeterochromiaIridum");
            DropTable("Characters.CharacterDatabaseItems");
        }
        
        public override void Down()
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
                        AppearanceId = c.Guid(nullable: false),
                        MetadataId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.Culture });
            
            AddColumn("Characters.AppearanceItems", "HeterochromiaIridum", c => c.Boolean(nullable: false));
            DropForeignKey("Characters.CharacterItems", "PortraitId", "Characters.Portraits");
            DropForeignKey("Characters.CharacterItems", "MetadataId", "Characters.Metadata");
            DropForeignKey("Characters.CharacterItems", "AppearanceId", "Characters.AppearanceItems");
            DropIndex("Characters.CharacterItems", new[] { "AppearanceId" });
            DropIndex("Characters.CharacterItems", new[] { "MetadataId" });
            DropIndex("Characters.CharacterItems", new[] { "PortraitId" });
            DropColumn("Characters.AppearanceItems", "SpecialFeatures");
            DropTable("Characters.Portraits");
            DropTable("Characters.CharacterItems");
            CreateIndex("Characters.CharacterDatabaseItems", "MetadataId");
            CreateIndex("Characters.CharacterDatabaseItems", "AppearanceId");
            AddForeignKey("Characters.CharacterDatabaseItems", "MetadataId", "Characters.Character_Metadata", "Id", cascadeDelete: true);
            AddForeignKey("Characters.CharacterDatabaseItems", "AppearanceId", "Characters.Character_Appearance", "Id", cascadeDelete: true);
            RenameTable(name: "Characters.Metadata", newName: "Character_Metadata");
            RenameTable(name: "Characters.AppearanceItems", newName: "Character_Appearance");
        }
    }
}
