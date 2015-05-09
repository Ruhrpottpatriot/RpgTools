namespace RpgTools.Characters.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "Characters.CharacterDatabaseItems", name: "ApprearanceId", newName: "AppearanceId");
            RenameIndex(table: "Characters.CharacterDatabaseItems", name: "IX_ApprearanceId", newName: "IX_AppearanceId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "Characters.CharacterDatabaseItems", name: "IX_AppearanceId", newName: "IX_ApprearanceId");
            RenameColumn(table: "Characters.CharacterDatabaseItems", name: "AppearanceId", newName: "ApprearanceId");
        }
    }
}
