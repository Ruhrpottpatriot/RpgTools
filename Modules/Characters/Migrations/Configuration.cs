namespace RpgTools.Characters.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RpgTools.Characters.CharactersRepository>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CharactersRepository context)
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
            Guid[] ids =
            {
                new Guid("13cbbdc8-d2e6-4a9a-9525-fa9043a53082"),
                new Guid("3a34fd9b-a6e3-4567-af83-840ddf4417ba"),
                new Guid("b1256f9f-8a35-416a-8f22-6be91ffb4041"),
                new Guid("2e24283d-1ba0-4cc7-b49c-975937e8512c")
            };

            var char1 = new CharacterDataContract
                        {
                            Age = 22,
                            Appearance =
                                new AppearanceDataContract
                                {
                                    Bust = 92,
                                    CupSize = "C",
                                    EyeColour = "green",
                                    Gender = 0,
                                    HairColour = "red"
                                },
                            Id = ids[0],
                            Name = "Ravia Hagen",
                            Metadata =
                                new MetadataDataContract
                                {
                                    IsAlive = true,
                                    CharacterId = ids[0],
                                    Appearances =
                                        "b1256f9f-8a35-416a-8f22-6be91ffb4041; 2e24283d-1ba0-4cc7-b49c-975937e8512c"
                                }
                        };

            var char2 = new CharacterDataContract
                        {
                            Age = 27,
                            Appearance =
                                new AppearanceDataContract
                                {
                                    Bust = 89,
                                    CupSize = "C",
                                    EyeColour = "green",
                                    Gender = 0
                                },
                            Id = ids[1],
                            Name = "Sarah Fenix",
                            Metadata =
                                new MetadataDataContract
                                {
                                    IsAlive = true,
                                    CharacterId = ids[1],
                                    Appearances =
                                        "b1256f9f-8a35-416a-8f22-6be91ffb4041; 2e24283d-1ba0-4cc7-b49c-975937e8512c"
                                }
                        };

            context.Characters.AddOrUpdate(c => c.Id, char1, char2);
        }
    }
}
