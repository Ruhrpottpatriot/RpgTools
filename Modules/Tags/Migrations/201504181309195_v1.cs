namespace RpgTools.Characters.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Tags.Tags",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Tag = c.String(),
                        Type = c.String(),
                        TwoLetterLanguageCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Tags.Tags");
        }
    }
}
