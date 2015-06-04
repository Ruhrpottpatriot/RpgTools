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
    using RpgTools.Core.Common.Converter;
    using RpgTools.Core.Models;
    using RpgTools.Locations.Converter;
    using RpgTools.Locations.DataContracts;

    /// <summary>The location repository.</summary>
    public sealed class LocationRepository : DbContext, ILocationRepository
    {
        /// <summary>Infrastructure. Holds a reference to the response converter.</summary>
        private readonly IConverter<IResponse<LocationDatabaseItem>, Location> responseConverter;

        /// <summary>Infrastructure. Holds a reference to the bulk response converter.</summary>
        private readonly IConverter<IResponse<ICollection<LocationDatabaseItem>>, IDictionaryRange<Guid, Location>> dictionaryRangeResponseConverter;

        /// <summary>Initialises a new instance of the <see cref="LocationRepository"/> class.</summary>
        public LocationRepository()
            : this(new LocationConverter(), new LocationDataContractConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="LocationRepository"/> class.</summary>
        /// <param name="locationConverter">The location converter.</param>
        /// <param name="writeConverter">The write Converter.</param>
        private LocationRepository(IConverter<LocationDatabaseItem, Location> locationConverter, IConverter<Location, LocationDatabaseItem> writeConverter)
            : base("name=RpgTools")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LocationRepository, Migrations.Configuration>(true));

            this.Locations = this.Set<LocationDatabaseItem>();

            this.responseConverter = new ResponseConverter<LocationDatabaseItem, Location>(locationConverter);
            this.dictionaryRangeResponseConverter = new DictionaryRangeConverter<LocationDatabaseItem, Guid, Location>(locationConverter, location => location.Id);
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <summary>Gets or sets the locations.</summary>
        internal DbSet<LocationDatabaseItem> Locations { get; set; }

        /// <inheritdoc />
        Location IRepository<Guid, Location>.Find(Guid identifier)
        {
            var data = new Response<LocationDatabaseItem>
                       {
                           Content = this.Locations.Single(l => l.Id == identifier),
                           Culture = ((ILocalizable)this).Culture
                       };
            return this.responseConverter.Convert(data);
        }
        
        /// <inheritdoc />
        IDictionaryRange<Guid, Location> IRepository<Guid, Location>.FindAll(ICollection<Guid> identifiers)
        {
            var data = new Response<ICollection<LocationDatabaseItem>>
                       {
                           Content = this.Locations.Where(c => identifiers.Any(i => i == c.Id)).ToList(),
                           Culture = ((ILocalizable)this).Culture
                       };

            return this.dictionaryRangeResponseConverter.Convert(data);
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Location> IRepository<Guid, Location>.FindAll()
        {
            var data = new Response<ICollection<LocationDatabaseItem>>
            {
                Content = this.Locations.ToList(),
                Culture = ((ILocalizable)this).Culture
            };

            return this.dictionaryRangeResponseConverter.Convert(data);
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
    }
}
