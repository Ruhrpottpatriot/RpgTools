// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationRepositoryFactory.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations
{
    using System.Data.Entity.Infrastructure;
    using System.Globalization;

    using RpgTools.Core.Common;

    /// <summary>Provides methods for creating repository object in specified cultures.</summary>
    public sealed class LocationRepositoryFactory : RepositoryFactoryBase<ILocationRepository>, IDbContextFactory<LocationRepository>
    {
        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override ILocationRepository ForDefaultCulture()
        {
            return new LocationRepository(new LocationReadConverter(), new LocationWriteConverter());
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override ILocationRepository ForCulture(CultureInfo culture)
        {
            ILocationRepository repository = new LocationRepository(new LocationReadConverter(), new LocationWriteConverter());
            repository.Culture = culture;
            return repository;
        }
        
        /// <summary>Creates a new instance of a derived <see cref="T:System.Data.Entity.DbContext"/> type.</summary>
        /// <returns>An instance of TContext.</returns>
        public LocationRepository Create()
        {
            return new LocationRepository(new LocationReadConverter(), new LocationWriteConverter());
        }
    }
}
