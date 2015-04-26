// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the Configuration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Tags.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using RpgTools.Tags;

    /// <summary>Describes the database configuration.</summary>
    internal sealed class Configuration : DbMigrationsConfiguration<TagsRepository>
    {
        /// <summary>Initialises a new instance of the <see cref="Configuration"/> class.</summary>
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
        protected override void Seed(TagsRepository context)
        {
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
