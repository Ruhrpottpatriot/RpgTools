// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the Configuration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using RpgTools.Locations.DataContracts;

    internal sealed class Configuration : DbMigrationsConfiguration<LocationRepository>
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <remarks>
        /// Note that the database may already contain seed data when this method runs. This means that
        /// implementations of this method must check whether or not seed data is present and/or up-to-date
        /// and then only make changes if necessary and in a non-destructive way. The 
        /// <see cref="M:System.Data.Entity.Migrations.DbSetMigrationsExtensions.AddOrUpdate``1(System.Data.Entity.IDbSet{``0},``0[])"/>
        /// can be used to help with this, but for seeding large amounts of data it may be necessary to do less
        /// granular checks if performance is an issue.
        /// If the <see cref="T:System.Data.Entity.MigrateDatabaseToLatestVersion`2"/> database 
        /// initializer is being used, then this method will be called each time that the initializer runs.
        /// If one of the <see cref="T:System.Data.Entity.DropCreateDatabaseAlways`1"/>, <see cref="T:System.Data.Entity.DropCreateDatabaseIfModelChanges`1"/>,
        /// or <see cref="T:System.Data.Entity.CreateDatabaseIfNotExists`1"/> initializers is being used, then this method will not be
        /// called and the Seed method defined in the initializer should be used instead.
        /// </remarks>
        /// <param name="context">Context to be used for updating seed data. </param>
        protected override void Seed(LocationRepository context)
        {
            // This method will be called after migrating to the latest version.
            // You can use the DbSet<T>.AddOrUpdate() helper extension method 
            // to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            var ids = new[]
            {
                new Guid("df922009-3611-4faf-85b4-3e78f55113f6"),
                new Guid("ffc46d7c-8012-491a-990e-1ab4efc4055a"),
                new Guid("5070d35b-94db-49b0-9c7a-895682a49a27"),
                new Guid("6c268c49-15b7-4138-8551-0b3f28243928"), 
            };

            context.Locations.AddOrUpdate(l => l.Id,
                new LocationDataContract
                {
                    Id = ids[0],
                    Name = "Stromsang",
                    Type = "City",
                    Details = new CityDetailsDataContract
                    {
                        Planet = ids[1],
                        Population = 10000,
                        IsCapital = false
                    }
                },
                new LocationDataContract
                {
                    Id = ids[1],
                    Name = "Noctus",
                    Type = "Planet",
                    Details = new PlanetDetailsDataContract
                    {
                        Population = 100000,
                        System = ids[2]
                    }
                },
                new LocationDataContract
                {
                    Id = ids[2],
                    Name = "Wakatsu Made",
                    Type = "System",
                    Details = new StarSystemDetailsDataContract
                    {
                        Population = 45512,
                        Sector = ids[3]
                    }
                },
                new LocationDataContract
                {
                    Id = ids[3],
                    Name = "Eastern Fringe",
                    Type = "Sector",
                    Details = new SectorDetailsDataContract
                    {
                        Population = 9786757
                    }
                });
        }
    }
}
