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
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;
    using EntityFramework.Extensions;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>The location repository.</summary>
    public sealed class LocationRepository : DbContext, ILocationReadableRepository
    {
        /// <summary>Used to convert single database items into an object used by the program.</summary>
        private readonly IConverter<IDataContainer<LocationDatabaseItem>, Location> responseConverter;

        /// <summary>Used to convert multiple data items into objects used by the program.</summary>
        private readonly IConverter<IDataContainer<ICollection<LocationDatabaseItem>>, IDictionaryRange<Guid, Location>> dictionaryRangeResponseConverter;

        /// <summary>Used to convert objects by the program into items stored in the database.</summary>
        private readonly IConverter<IDataContainer<Location>, LocationDatabaseItem> writeConverter;

        /// <summary>Initialises a new instance of the <see cref="LocationRepository"/> class.</summary>
        /// <param name="locationConverter">The location converter.</param>
        /// <param name="writeConverter">The write Converter.</param>
        internal LocationRepository(IConverter<LocationDatabaseItem, Location> locationConverter, IConverter<Location, LocationDatabaseItem> writeConverter)
            : base("name=RpgTools")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LocationRepository, Migrations.Configuration>(true));
            this.Locations = this.Set<LocationDatabaseItem>();

            this.responseConverter = new DataConverter<LocationDatabaseItem, Location>(locationConverter);
            this.dictionaryRangeResponseConverter = new DictionaryRangeConverter<LocationDatabaseItem, Guid, Location>(locationConverter, location => location.Id);
            this.writeConverter = new DataConverter<Location, LocationDatabaseItem>(writeConverter);
        }

        /// <summary>Gets or sets the culture.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets or sets the locations.</summary>
        internal DbSet<LocationDatabaseItem> Locations { get; set; }

        /// <inheritdoc />
        public Location Find(Guid identifier)
        {
            IDataContainer<LocationDatabaseItem> data = this.CreateContainer(this.Locations.Single(l => l.Id == identifier), this.Culture);
            return this.responseConverter.Convert(data);
        }

        /// <inheritdoc />
        public IDictionaryRange<Guid, Location> FindAll(ICollection<Guid> identifiers)
        {
            IDataContainer<ICollection<LocationDatabaseItem>> data = this.CreateContainer<ICollection<LocationDatabaseItem>>(
                this.Locations.Where(c => identifiers.Any(i => i == c.Id)).ToList(), 
                this.Culture);

            return this.dictionaryRangeResponseConverter.Convert(data);
        }

        /// <inheritdoc />
        public IDictionaryRange<Guid, Location> FindAll()
        {
            IDataContainer<ICollection<LocationDatabaseItem>> data = this.CreateContainer<ICollection<LocationDatabaseItem>>(this.Locations.ToList(), this.Culture);

            return this.dictionaryRangeResponseConverter.Convert(data);
        }

        /// <summary>Deletes a specific item from the database.</summary>
        /// <param name="identifier">The item to delete.</param>
        public void Delete(Guid identifier)
        {
            this.Locations.Where(l => l.Id == identifier).Delete();
        }

        /// <summary>Creates a new item in the repository.</summary>
        /// <param name="data">The data to write to the repository.</param>
        public void Create(IDataContainer<Location> data)
        {
            LocationDatabaseItem convertedData = this.writeConverter.Convert(data);
            this.Locations.Add(convertedData);
            this.SaveChanges();
        }

        /// <summary>Updates an item in the repository with the given data.</summary>
        /// <param name="data">The new data to store in the repository.</param>
        public void Update(IDataContainer<Location> data)
        {
            LocationDatabaseItem convertedData = this.writeConverter.Convert(data);
            this.Locations.AddOrUpdate(convertedData);
            this.SaveChanges();
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

        private IDataContainer<TData> CreateContainer<TData>(TData data, CultureInfo culture = null, DateTimeOffset? date = null)
        {
            return new DataContainer<TData>
            {
                Content = data,
                Culture = culture,
                Date = date
            };
        }
    }
}
