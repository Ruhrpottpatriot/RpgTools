namespace RpgTools.Tags.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using RpgTools.Characters;
    using RpgTools.Tags;

    internal sealed class Configuration : DbMigrationsConfiguration<TagsRepository>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TagsRepository context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            Guid[] guids = 
            {
                new Guid("1967121a-70aa-41fc-bc6f-9d63d97b2d50"),
                new Guid("5e89bffd-f151-4fd8-b8ee-832ae4c0460e"),
                new Guid("bf747339-96a7-43ca-af31-70d8249dc849"),
                new Guid("de900230-152a-48e9-bef2-c380c19af02c"),
                new Guid("1460c9f7-f21b-4b6d-8a2f-fcbab1c61a53")
            };

            context.Tags.AddOrUpdate(
                t => t.Id,
                new TagDataContract
                {
                    Id = guids[0],
                    Tag = "Protagonist",
                    TwoLetterLanguageCode = "en",
                    Type = "Character"
                },
                new TagDataContract
                {
                    Id = guids[1],
                    Tag = "Antagonist",
                    TwoLetterLanguageCode = "en",
                    Type = "Character"
                },
                new TagDataContract
                {
                    Id = guids[2],
                    Tag = "Female",
                    TwoLetterLanguageCode = "en",
                    Type = "Character"
                },
                new TagDataContract
                {
                    Id = guids[3],
                    Tag = "Noctus",
                    TwoLetterLanguageCode = "en",
                    Type = "Character"
                },
                new TagDataContract
                {
                    Id = guids[4],
                    Tag = "Prinzipat",
                    TwoLetterLanguageCode = "de",
                    Type = "Character"
                });
        }
    }
}
