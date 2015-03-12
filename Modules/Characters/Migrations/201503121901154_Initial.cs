namespace Characters.Migrations
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
                        Age = c.Int(),
                        Motto = c.String(),
                        Nickname = c.String(),
                        Name = c.String(),
                        Title = c.String(),
                        IsAlive = c.Boolean(),
                        VoiceActor = c.String(),
                        Portrait = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Characters.PhysicalApperance",
                c => new
                    {
                        CharacterId = c.Guid(nullable: false),
                        Height = c.Int(nullable: false),
                        Bust = c.Short(nullable: false),
                        CupSize = c.String(),
                        Hip = c.Short(nullable: false),
                        Waist = c.Short(nullable: false),
                        Gender = c.String(),
                        SkinColour = c.String(),
                        EyeColour = c.String(),
                        HairColour = c.String(),
                        HeterochromiaIridum = c.Boolean(nullable: false),
                        LipColour = c.String(),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("Characters.Characters", t => t.CharacterId)
                .Index(t => t.CharacterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Characters.PhysicalApperance", "CharacterId", "Characters.Characters");
            DropIndex("Characters.PhysicalApperance", new[] { "CharacterId" });
            DropTable("Characters.PhysicalApperance");
            DropTable("Characters.Characters");
        }
    }
}
