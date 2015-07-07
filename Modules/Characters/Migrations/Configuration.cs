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
    using RpgTools.Core.Models;

    /// <summary>Configures the database migrations.</summary>
    internal sealed class Configuration : DbMigrationsConfiguration<CharacterRepository>
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <remarks>
        /// Note that the database may already contain seed data when this method runs. This means that
        ///             implementations of this method must check whether or not seed data is present and/or up-to-date
        ///             and then only make changes if necessary and in a non-destructive way. The 
        ///             <see cref="M:System.Data.Entity.Migrations.DbSetMigrationsExtensions.AddOrUpdate``1(System.Data.Entity.IDbSet{``0},``0[])"/>
        ///             can be used to help with this, but for seeding large amounts of data it may be necessary to do less
        ///             granular checks if performance is an issue.
        ///             If the <see cref="T:System.Data.Entity.MigrateDatabaseToLatestVersion`2"/> database 
        ///             initializer is being used, then this method will be called each time that the initializer runs.
        ///             If one of the <see cref="T:System.Data.Entity.DropCreateDatabaseAlways`1"/>, <see cref="T:System.Data.Entity.DropCreateDatabaseIfModelChanges`1"/>,
        ///             or <see cref="T:System.Data.Entity.CreateDatabaseIfNotExists`1"/> initializers is being used, then this method will not be
        ///             called and the Seed method defined in the initializer should be used instead.
        /// </remarks>
        /// <param name="context">Context to be used for updating seed data. </param>
        protected override void Seed(CharacterRepository context)
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

            CharacterItem char1 = new CharacterItem
            {
                Age = 22,
                Appearance = new AppearanceItem
                {
                    Bust = 90,
                    CupSize = 'C',
                    EyeColour = "Green",
                    Gender = Genders.Female,
                    HairColour = "Red",
                    Height = 188,
                    Hip = 60,
                    Id = ids[1],
                    LipColour = "red",
                    SkinColour = "fair",
                    Waist = 90,
                    Weight = 76
                },
                Id = ids[0],
                Metadata = new CharacterMetadataItem
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

            var char2 = new CharacterItem
            {
                Age = 22,
                Appearance = new AppearanceItem
                {
                    Bust = 90,
                    CupSize = 'C',
                    EyeColour = "Green",
                    Gender = Genders.Female,
                    HairColour = "Red",
                    Height = 188,
                    Hip = 60,
                    Id = ids[4],
                    LipColour = "red",
                    SkinColour = "fair",
                    Waist = 90,
                    Weight = 76
                },
                Id = ids[3],
                Metadata = new CharacterMetadataItem
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
