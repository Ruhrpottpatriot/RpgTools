// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationRepositoryFactory.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations
{
    using System.Globalization;

    using RpgTools.Core.Common;

    /// <summary>Provides methods for creating repository object in specified cultures.</summary>
    public sealed class LocationRepositoryFactory : RepositoryFactoryBase<ILocationRepository>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IAuthorizedServiceClient serviceClient;

        /// <summary> Initialises a new instance of the <see cref="LocationRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public LocationRepositoryFactory(IAuthorizedServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override ILocationRepository ForDefaultCulture()
        {
            return new LocationRepository(this.serviceClient);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override ILocationRepository ForCulture(CultureInfo culture)
        {
            ILocationRepository repository = new LocationRepository(this.serviceClient);
            repository.Culture = culture;
            return repository;
        }
    }
}
