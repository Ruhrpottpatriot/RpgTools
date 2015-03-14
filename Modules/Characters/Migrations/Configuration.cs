// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Characters.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using Characters.DataContracts;

    using RpgTools.Core.Common;

    /// <summary>
    /// The configuration.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<CharacterContext>
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        /// <inheritdoc />
        protected override void Seed(CharacterContext context)
        {
            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method 
            // to avoid creating duplicate seed data. E.g.
            // context.People.AddOrUpdate(
            // p => p.FullName,
            // new Person { FullName = "Andrew Peters" },
            // new Person { FullName = "Brice Lambson" },
            // new Person { FullName = "Rowan Miller" }
            // );
            var ids = new[]
                          {
                              new Guid("b971e4f1-bd3f-4a36-867a-b9edd75ddb3c"),
                              new Guid("d09e56eb-8383-4770-8181-0821cdd62627"),
                              new Guid("8ae476f2-dc4d-4103-9746-c84a14160774"),
                              new Guid("f28eaf77-076b-4425-a511-bdb349f897ae")
                          };

            context.Characters.AddOrUpdate(c => c.Id,
                new CharacterDataContract
                {
                    Age = 21,
                    Appearance = new PhysicalApperance
                    {
                        Bust = 87,
                        CupSize = "C",
                        EyeColour = "#FF00C813",
                        Gender = "Female",
                        HairColour = "#FF800000",
                        Height = 180,
                        HeterochromiaIridum = false,
                        Hip = 62,
                        LipColour = "#FFB31B1B",
                        SkinColour = "Fair",
                        Waist = 84
                    },
                    Id = ids[0],
                    IsAlive = true,
                    Motto = string.Empty,
                    Name = "Ravia Hagen",
                    Nickname = "Blitz",
                    Portrait = null,
                    Tags = null,
                    Title = "Sergeant",
                    VoiceActor = "Grey de Lise"
                });

        }
    }
}
