namespace RpgTools.Locations.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using RpgTools.Locations.DataContracts;

    internal sealed class Configuration : DbMigrationsConfiguration<RpgTools.Locations.LocationRepository>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RpgTools.Locations.LocationRepository context)
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


            context.LocationsDbSet.AddOrUpdate(
                l => l.Id,
                new LocationDataContract
                {
                    Id = ids[0],
                    Name = "Stromsang",
                    Type = "City",
                    Details =
                        new CityDetailsDataContract
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
                    Details =
                        new PlanetDetailsDataContract { Population = 100000, System = ids[2] }
                },
                new LocationDataContract
                {
                    Id = ids[2],
                    Name = "Wakatsu Made",
                    Type = "System",
                    Details =
                        new StarSystemDetailsDataContract { Population = 45512, Sector = ids[3] }
                },
                new LocationDataContract
                {
                    Id = ids[3],
                    Name = "Eastern Fringe",
                    Type = "Sector",
                    Details = new SectorDetailsDataContract { Population = 9786757 }
                });
        }
    }
}
