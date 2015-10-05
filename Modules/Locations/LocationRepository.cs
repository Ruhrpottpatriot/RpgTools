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
    using System.Threading;
    using System.Threading.Tasks;

    using EntityFramework.Extensions;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>The location repository.</summary>
    public sealed class LocationRepository : DbContext, ILocationRepository
    {
        /// <summary>Used to convert single database items into an object used by the program.</summary>
        private readonly IConverter<IDataContainer<LocationDatabaseItem>, Location> readConverter;

        /// <summary>Used to convert multiple data items into objects used by the program.</summary>
        private readonly IConverter<IDataContainer<ICollection<LocationDatabaseItem>>, IDictionaryRange<Guid, Location>> bulkReadConverter;

        /// <summary>Used to convert objects by the program into items stored in the database.</summary>
        private readonly IConverter<IDataContainer<Location>, LocationDatabaseItem> writeConverter;

        /// <summary>Initializes a new instance of the <see cref="LocationRepository"/> class.</summary>
        /// <param name="readConverter">The location converter.</param>
        /// <param name="writeConverter">The write Converter.</param>
        internal LocationRepository(IConverter<LocationDatabaseItem, Location> readConverter, IConverter<Location, LocationDatabaseItem> writeConverter)
            : base("name=RpgTools")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LocationRepository, Migrations.Configuration>(true));
            this.Locations = this.Set<LocationDatabaseItem>();

            this.readConverter = new DataConverter<LocationDatabaseItem, Location>(readConverter);
            this.bulkReadConverter = new DictionaryRangeConverter<LocationDatabaseItem, Guid, Location>(readConverter, location => location.Id);
            this.writeConverter = new DataConverter<Location, LocationDatabaseItem>(writeConverter);
        }

        /// <summary>Gets or sets the culture.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets or sets the locations.</summary>
        internal DbSet<LocationDatabaseItem> Locations { get; set; }
        
        /// <inheritdoc />
        public Task<Location> FindAsync(Guid identifier)
        {
            return this.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        public async Task<Location> FindAsync(Guid identifier, CancellationToken cancellationToken)
        {
            Task<IDataContainer<LocationDatabaseItem>> data = Task.Run(() => this.CreateContainer(this.Locations.Single(l => l.Id == identifier), this.Culture), cancellationToken);
            return this.readConverter.Convert(await data);
        }

        /// <inheritdoc />
        public Task<IDictionaryRange<Guid, Location>> FindAllAsync()
        {
            return this.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        public async Task<IDictionaryRange<Guid, Location>> FindAllAsync(CancellationToken cancellationToken)
        {
            var data = Task.Run(() => this.CreateContainer<ICollection<LocationDatabaseItem>>(this.Locations.ToList(), this.Culture), cancellationToken);

            return this.bulkReadConverter.Convert(await data);
        }

        /// <inheritdoc />
        public Task<IDictionaryRange<Guid, Location>> FindAllAsync(ICollection<Guid> identifiers)
        {
            return this.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        public async Task<IDictionaryRange<Guid, Location>> FindAllAsync(ICollection<Guid> identifiers, CancellationToken cancellationToken)
        {
            var data = Task.Run(
                () => this.CreateContainer<ICollection<LocationDatabaseItem>>(
                this.Locations.Where(c => identifiers.Any(i => i == c.Id)).ToList(),
                this.Culture), cancellationToken);

            return this.bulkReadConverter.Convert(await data);
        }

        /// <summary>Creates a new item in the repository.</summary>
        /// <param name="data">The data to write to the repository.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <inheritdoc />
        public Task CreateAsync(IDataContainer<Location> data)
        {
            return this.CreateAsync(data, CancellationToken.None);
        }

        /// <inheritdoc />
        public async Task CreateAsync(IDataContainer<Location> data, CancellationToken cancellationToken)
        {
            LocationDatabaseItem convertedData = this.writeConverter.Convert(data);
            this.Locations.Add(convertedData);
            await this.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc />
        public Task UpdateAsync(IDataContainer<Location> data)
        {
            return this.UpdateAsync(data, CancellationToken.None);
        }

        /// <inheritdoc />
        public async Task UpdateAsync(IDataContainer<Location> data, CancellationToken cancellationToken)
        {
            LocationDatabaseItem convertedData = this.writeConverter.Convert(data);
            this.Locations.AddOrUpdate(convertedData);
            await this.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc />
        public Task DeleteAsync(Guid identifier)
        {
            return this.DeleteAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(Guid identifier, CancellationToken cancellationToken)
        {
            this.Locations.Where(l => l.Id == identifier).Delete();

            await this.SaveChangesAsync(cancellationToken);
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

        /// <summary>Creates the appropriate data container for converting data.</summary>
        /// <typeparam name="TData">The type of content to store in the container.</typeparam>
        /// <param name="data">The data to store in the container.</param>
        /// <param name="culture">The language of the data.</param>
        /// <param name="date">The date the data was requested.</param>
        /// <returns>An <see cref="IDataContainer{T}"/> containing the data to be converted and optional language and data.</returns>
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
