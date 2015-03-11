namespace RpgTools.Locations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Locations.SystemDetails", newName: "StarSystemDetails");
        }
        
        public override void Down()
        {
            RenameTable(name: "Locations.StarSystemDetails", newName: "SystemDetails");
        }
    }
}
