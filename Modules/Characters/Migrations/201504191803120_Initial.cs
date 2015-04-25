namespace RpgTools.Characters.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        ShortDescription = c.String(),
                        Motto = c.String(),
                        Age = c.Int(nullable: false),
                        Portrait = c.Binary(),
                        OriginId = c.Guid(nullable: false),
                        FamilyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Characters.Occurrences",
                c => new
                    {
                        CharacterId = c.Guid(nullable: false),
                        Height = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        SkinColour = c.String(),
                        EyeColour = c.String(),
                        HeterochromiaIridum = c.Boolean(nullable: false),
                        HairColour = c.String(),
                        LipColour = c.String(),
                        Bust = c.Short(nullable: false),
                        CupSize = c.String(),
                        Hip = c.Short(nullable: false),
                        Waist = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("Characters.Characters", t => t.CharacterId)
                .Index(t => t.CharacterId);
            
            CreateTable(
                "Characters.Metadata",
                c => new
                    {
                        CharacterId = c.Guid(nullable: false),
                        IsAlive = c.Boolean(nullable: false),
                        Tags = c.String(),
                        ValidDate = c.String(),
                        VoiceActor = c.String(),
                        Appearances = c.String(),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("Characters.Characters", t => t.CharacterId)
                .Index(t => t.CharacterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Characters.Metadata", "CharacterId", "Characters.Characters");
            DropForeignKey("Characters.Occurrences", "CharacterId", "Characters.Characters");
            DropIndex("Characters.Metadata", new[] { "CharacterId" });
            DropIndex("Characters.Occurrences", new[] { "CharacterId" });
            DropTable("Characters.Metadata");
            DropTable("Characters.Occurrences");
            DropTable("Characters.Characters");
        }
    }
}
