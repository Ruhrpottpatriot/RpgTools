// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationRepository.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Globalization;
    using System.Linq;

    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>The location repository.</summary>
    public sealed class LocationReadableRepository : DbContext, ILocationReadableRepository
    {
        /// <summary>Used to convert single database items into an object used by the program.</summary>
        private readonly IConverter<IResponse<LocationDatabaseItem>, Location> responseConverter;

        /// <summary>Used to convert multiple data items into objects used by the program.</summary>
        private readonly IConverter<IResponse<ICollection<LocationDatabaseItem>>, IDictionaryRange<Guid, Location>> dictionaryRangeResponseConverter;

        /// <summary>Used to convert objects by the program into items stored in the database.</summary>
        private IConverter<Location, LocationDatabaseItem> writeConverter;

        /// <summary>Initialises a new instance of the <see cref="LocationReadableRepository"/> class.</summary>
        public LocationReadableRepository()
            : this(new LocationConverter(), new LocationDataContractConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="LocationReadableRepository"/> class.</summary>
        /// <param name="locationConverter">The location converter.</param>
        /// <param name="writeConverter">The write Converter.</param>
        private LocationReadableRepository(IConverter<LocationDatabaseItem, Location> locationConverter, IConverter<Location, LocationDatabaseItem> writeConverter)
            : base("name=RpgTools")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LocationReadableRepository, Migrations.Configuration>(true));
            this.Locations = this.Set<LocationDatabaseItem>();

            this.responseConverter = new DataConverter<LocationDatabaseItem, Location>(locationConverter);
            this.dictionaryRangeResponseConverter = new DictionaryRangeConverter<LocationDatabaseItem, Guid, Location>(locationConverter, location => location.Id);
            this.writeConverter = writeConverter;
        }

        /// <summary>Gets or sets the culture.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets or sets the locations.</summary>
        internal DbSet<LocationDatabaseItem> Locations { get; set; }

        /// <inheritdoc />
        Location IReadableRepository<Guid, Location>.Find(Guid identifier)
        {
            var data = new Response<LocationDatabaseItem>
                       {
                           Content = this.Locations.Single(l => l.Id == identifier),
                           Culture = this.Culture
                       };
            return this.responseConverter.Convert(data);
        }
        
        /// <inheritdoc />
        IDictionaryRange<Guid, Location> IReadableRepository<Guid, Location>.FindAll(ICollection<Guid> identifiers)
        {
            var data = new Response<ICollection<LocationDatabaseItem>>
                       {
                           Content = this.Locations.Where(c => identifiers.Any(i => i == c.Id)).ToList(),
                           Culture = this.Culture
                       };

            return this.dictionaryRangeResponseConverter.Convert(data);
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Location> IReadableRepository<Guid, Location>.FindAll()
        {
            var data = new Response<ICollection<LocationDatabaseItem>>
            {
                Content = this.Locations.ToList(),
                Culture = this.Culture
            };

            return this.dictionaryRangeResponseConverter.Convert(data);
        }

        /// <summary>Writes the data to the repository.</summary>
        /// <param name="data">The data to write.</param>
        public void Write(Location data)
        {
            throw new NotImplementedException();
        }

        /// <summary>Deletes a specific item from the database.</summary>
        /// <param name="data">The item to delete.</param>
        public void Delete(Location data)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Locations");

            modelBuilder.Entity<CityDetailsDataContract>().Map(
                m =>
                {
                    m.MapInheritedProperties();
                });

            modelBuilder.Entity<PlanetDetailsDataContract>().Map(
                m =>
                {
                    m.MapInheritedProperties();
                });

            modelBuilder.Entity<StarSystemDetailsDataContract>().Map(
                m =>
                {
                    m.MapInheritedProperties();
                });

            modelBuilder.Entity<SectorDetailsDataContract>().Map(
                m =>
                {
                    m.MapInheritedProperties();
                });
        }
    }
}
