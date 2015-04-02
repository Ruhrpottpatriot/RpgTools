namespace RpgTools.Locations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Locations.Locations", "Details_Id", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("Locations.Locations", "Details_Id");
        }
    }
}
