// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationRepository.cs" company="Robert Logiewa">
//   (C) All rights reseved
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

    using RpgTools.Core.Common;
    using RpgTools.Core.Models.Locations;
    using RpgTools.Locations.Converter;
    using RpgTools.Locations.DataContracts;

    /// <summary>The location repository.</summary>
    public sealed class LocationRepository : DbContext, ILocationRepository
    {
        /// <summary>Infrastructure. Holds a reference to the response converter.</summary>
        private readonly IConverter<IResponse<LocationDataContract>, Location> responseConverter;

        /// <summary>Infrastructure. Holds a reference to the write converter.</summary>
        private readonly IConverter<Location, LocationDataContract> writeConverter;

        /// <summary>Infrastructure. Holds a reference to the bulk response converter.</summary>
        private readonly IConverter<IResponse<ICollection<LocationDataContract>>, IDictionaryRange<Guid, Location>> bulkResponseConverter;

        /// <summary>Initialises a new instance of the <see cref="LocationRepository"/> class.</summary>
        public LocationRepository()
            : this(new LocationConverter(), new LocationDataContractConverter())
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="LocationRepository"/> class.
        /// </summary>
        /// <param name="locationConverter">
        /// The location converter.
        /// </param>
        /// <param name="writeConverter">
        /// The write Converter.
        /// </param>
        internal LocationRepository(IConverter<LocationDataContract, Location> locationConverter, IConverter<Location, LocationDataContract> writeConverter)
            : base("name=RpgTools")
        {
            // Set the initializer. ToDo: Needs to be changed for production enviroment.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LocationRepository, Migrations.Configuration>(true));

            this.LocationsDbSet = this.Set<LocationDataContract>();

            this.responseConverter = new ResponseConverter<LocationDataContract, Location>(locationConverter);
            this.bulkResponseConverter = new DictionaryRangeConverter<LocationDataContract, Guid, Location>(locationConverter, location => location.Id);

            this.writeConverter = writeConverter;
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <summary>Gets or sets the locations data set.</summary>
        internal DbSet<LocationDataContract> LocationsDbSet { get; set; }

        /// <inheritdoc />
        ICollection<Guid> IDiscoverable<Guid>.Discover()
        {
            return this.LocationsDbSet.Select(loc => loc.Id).ToList();
        }

        /// <inheritdoc />
        Task<ICollection<Guid>> IDiscoverable<Guid>.DiscoverAsync()
        {
            ILocationRepository self = this;
            return self.DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<Guid>> IDiscoverable<Guid>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var task = new Task<ICollection<Guid>>(
                () =>
                {
                    return this.LocationsDbSet.Select(loc => loc.Id).ToList();
                }, cancellationToken);

            return task;
        }

        /// <inheritdoc />
        Location IRepository<Guid, Location>.Find(Guid identifier)
        {
            var location = this.LocationsDbSet.SingleOrDefault(l => l.Id == identifier);

            this.GetLocationWithDetails(location);

            var response = this.CreateResponse(location, null, null);

            return this.responseConverter.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Location> IRepository<Guid, Location>.FindAll(ICollection<Guid> identifiers)
        {
            ICollection<LocationDataContract> locations = this.LocationsDbSet.Where(l => identifiers.Any(i => i == l.Id)).ToList();

            foreach (var location in locations)
            {
                this.GetLocationWithDetails(location);
            }

            var response = this.CreateResponse(locations, null, null);

            IDictionaryRange<Guid, Location> result = this.bulkResponseConverter.Convert(response);

            result.TotalCount = this.LocationsDbSet.Count();
            result.SubtotalCount = result.Count;

            return result;
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Location> IRepository<Guid, Location>.FindAll()
        {
            ICollection<LocationDataContract> locations = this.LocationsDbSet.ToList();

            foreach (var location in locations)
            {
                this.GetLocationWithDetails(location);
            }

            var response = this.CreateResponse(locations, null, null);

            var result = this.bulkResponseConverter.Convert(response);
            result.SubtotalCount = result.Count;
            result.TotalCount = result.Count;

            return result;
        }

        /// <inheritdoc />
        void IWriteable<Location>.Write(Location data)
        {
            var dataContractToWrite = this.writeConverter.Convert(data);

            this.LocationsDbSet.AddOrUpdate(dataContractToWrite);

            this.SaveChanges();
        }

        /// <inheritdoc />
        void IWriteable<Location>.WriteAsync(Location data)
        {
            ILocationRepository self = this;
            self.WriteAsync(data, CancellationToken.None);
        }

        /// <inheritdoc />
        void IWriteable<Location>.WriteAsync(Location data, CancellationToken cancellationToken)
        {
            var dataContractToWrite = this.writeConverter.Convert(data);

            this.LocationsDbSet.AddOrUpdate(dataContractToWrite);

            this.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuilder, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        /// <param name="modelBuilder">The builder that defines the model for the context being created. </param>
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

        /// <summary>
        /// Gets the details of a <see cref="LocationDataContract"/>.
        /// </summary>
        /// <param name="location">
        /// The location to get the details for.
        /// </param>
        private void GetLocationWithDetails(LocationDataContract location)
        {
            switch (location.Type)
            {
                case "City":
                    location.Details = this.Set<CityDetailsDataContract>().Single(d => d.Id == location.Id);
                    break;
                case "Planet":
                    location.Details = this.Set<PlanetDetailsDataContract>().Single(d => d.Id == location.Id);
                    break;
                case "System":
                    location.Details = this.Set<StarSystemDetailsDataContract>().Single(d => d.Id == location.Id);
                    break;
                case "Sector":
                    location.Details = this.Set<SectorDetailsDataContract>().Single(d => d.Id == location.Id);
                    break;
            }
        }

        /// <summary>Placeholder. Creates a response for a converter.</summary>
        /// <param name="content">The content of the response.</param>
        /// <param name="cultureInfo">The culture info.</param>
        /// <param name="date">The date the query originated.</param>
        /// <typeparam name="TData">The type of the response data.</typeparam>
        /// <returns>A <see cref="IResponse{T}"/> with <see cref="TData"/> as content type.</returns>
        private IResponse<TData> CreateResponse<TData>(TData content, CultureInfo cultureInfo, DateTimeOffset? date)
        {
            return new Response<TData> { Content = content, Date = date, Culture = cultureInfo };
        }
    }
}
