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
    using System.Threading;
    using System.Threading.Tasks;

    using RpgTools.Core.Common;
    using RpgTools.Core.Common.Converter;
    using RpgTools.Core.Models;
    using RpgTools.Locations.Converter;
    using RpgTools.Locations.DataContracts;

    /// <summary>The location repository.</summary>
    public sealed class LocationRepository : DbContext, ILocationRepository
    {
        /// <summary>Infrastructure. Holds a reference to the identifiers converter.</summary>
        private readonly IConverter<IResponse<ICollection<Guid>>, ICollection<Guid>> identifiersConverter;

        /// <summary>Infrastructure. Holds a reference to the response converter.</summary>
        private readonly IConverter<IResponse<LocationDataContract>, Location> responseConverter;

        /// <summary>Infrastructure. Holds a reference to the write converter.</summary>
        private readonly IConverter<Location, LocationDataContract> writeConverter;

        /// <summary>Infrastructure. Holds a reference to the bulk response converter.</summary>
        private readonly IConverter<IResponse<ICollection<LocationDataContract>>, IDictionaryRange<Guid, Location>> dictionaryRangeResponseConverter;

        /// <summary>Initialises a new instance of the <see cref="LocationRepository"/> class.</summary>
        public LocationRepository()
            : this(new LocationConverter(), new ConverterAdapter<ICollection<Guid>>(), new LocationDataContractConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="LocationRepository"/> class.</summary>
        /// <param name="locationConverter">The location converter.</param>
        /// <param name="collectionConverter">The collection Converter.</param>
        /// <param name="writeConverter">The write Converter.</param>
        private LocationRepository(IConverter<LocationDataContract, Location> locationConverter, IConverter<ICollection<Guid>, ICollection<Guid>> collectionConverter, IConverter<Location, LocationDataContract> writeConverter)
            : base("name=RpgTools")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LocationRepository, Migrations.Configuration>(true));

            this.Locations = this.Set<LocationDataContract>();

            this.identifiersConverter = new ResponseConverter<ICollection<Guid>, ICollection<Guid>>(collectionConverter);
            this.responseConverter = new ResponseConverter<LocationDataContract, Location>(locationConverter);
            this.dictionaryRangeResponseConverter = new DictionaryRangeConverter<LocationDataContract, Guid, Location>(locationConverter, location => location.Id);

            this.writeConverter = writeConverter;
        }
        
        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <summary>Gets or sets the locations.</summary>
        internal DbSet<LocationDataContract> Locations { get; set; }

        /// <inheritdoc />
        Location IRepository<Guid, Location>.Find(Guid identifier)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Location> IRepository<Guid, Location>.FindAll(ICollection<Guid> identifiers)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Location> IRepository<Guid, Location>.FindAll()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<Guid, Location>> IRepository<Guid, Location>.FindAllAsync()
        {
            return ((ILocationRepository)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<Guid, Location>> IRepository<Guid, Location>.FindAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

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
