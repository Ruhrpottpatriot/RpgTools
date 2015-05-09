// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the Configuration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RpgTools.Characters.CharactersRepository>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CharactersRepository context)
        {
            Guid[] ids =
            {
                new Guid("13cbbdc8-d2e6-4a9a-9525-fa9043a53082"),
                new Guid("3a34fd9b-a6e3-4567-af83-840ddf4417ba"),
                new Guid("b1256f9f-8a35-416a-8f22-6be91ffb4041"),
                new Guid("2e24283d-1ba0-4cc7-b49c-975937e8512c"),
                new Guid("2f66d513-1839-4a26-be7e-39243d6807cf"),
                new Guid("b496a770-c62b-4a2a-bfb9-3992761b8a29"),
                new Guid("3e8c8fd9-fc4a-48c2-805f-5baec11b7fd2"),
                new Guid("b7675382-6011-4ec9-b405-3066ab0ce759"),
                new Guid("c20c730f-c013-4be4-b7db-ecebecf4b098"),
                new Guid("6bea1a0f-300e-4154-bde0-c8e3a6d21d08"),
                new Guid("c13c28e4-5441-4870-9afe-07778071c7e7"),
                new Guid("38daa883-c26d-40b4-ba0d-53296662d07c"),
                new Guid("4a83cd36-ff18-4ef1-955d-e4e935d28f5f"),
                new Guid("3b3345cc-a7f9-4c9d-8669-547cd7ecf3f5")
            };

            var char1 = new CharacterDatabaseItem
            {
                Age = 22,
                AppearanceDatabaseItem = new AppearanceDatabaseItem
                {
                    Bust = 90,
                    CupSize = 'C',
                    EyeColour = "Green",
                    Gender = 1,
                    HairColour = "Red",
                    Height = 188,
                    HeterochromiaIridum = false,
                    Hip = 60,
                    Id = ids[1],
                    LipColour = "red",
                    SkinColour = "fair",
                    Waist = 90,
                    Weight = 76
                },
                Culture = "en-GB",
                Id = ids[0],
                MetadataDatabaseItem = new MetadataDatabaseItem
                {
                    Id = ids[2],
                    Occurrences = string.Empty,
                    Tags = "Female; Protagonist",
                    VoiceActor = "Laura Bailey"
                },
                Motto = null,
                Name = "Sarah Fenix",
                Nickname = string.Empty,
                Portrait = null,
                Description = "Ravia Hagen's spouse",
                Title = string.Empty
            };

            var char2 = new CharacterDatabaseItem
            {
                Age = 22,
                AppearanceDatabaseItem = new AppearanceDatabaseItem
                {
                    Bust = 90,
                    CupSize = 'C',
                    EyeColour = "Green",
                    Gender = 1,
                    HairColour = "Red",
                    Height = 188,
                    HeterochromiaIridum = false,
                    Hip = 60,
                    Id = ids[4],
                    LipColour = "red",
                    SkinColour = "fair",
                    Waist = 90,
                    Weight = 76
                },
                Culture = "en-GB",
                Id = ids[3],
                MetadataDatabaseItem = new MetadataDatabaseItem
                {
                    Id = ids[5],
                    Occurrences = string.Empty,
                    Tags = "Female; Protagonist",
                    VoiceActor = "Laura Bailey"
                },
                Motto = null,
                Name = "Ravia Hagen",
                Nickname = string.Empty,
                Portrait = null,
                Description = "Sarah Fenix's spouse",
                Title = string.Empty
            };

            context.Characters.AddOrUpdate(c => c.Id, char1, char2);
        }
    }
}
