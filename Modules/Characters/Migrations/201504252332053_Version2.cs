namespace RpgTools.Characters.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Characters.Appearances", newName: "Occurrences");
            AddColumn("Characters.Metadata", "Occurrences", c => c.String());
            DropColumn("Characters.Metadata", "Appearances");
        }
        
        public override void Down()
        {
            AddColumn("Characters.Metadata", "Appearances", c => c.String());
            DropColumn("Characters.Metadata", "Occurrences");
            RenameTable(name: "Characters.Occurrences", newName: "Appearances");
        }
    }
}
