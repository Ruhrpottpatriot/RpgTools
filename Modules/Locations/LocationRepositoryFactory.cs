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
    public sealed class LocationRepositoryFactory : RepositoryFactoryBase<ILocationReadableRepository>
    {
        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override ILocationReadableRepository ForDefaultCulture()
        {
            return new LocationRepository(new LocationConverter(), new LocationDataContractConverter());
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override ILocationReadableRepository ForCulture(CultureInfo culture)
        {
            ILocationReadableRepository readableRepository = new LocationRepository(new LocationConverter(), new LocationDataContractConverter());
            readableRepository.Culture = culture;
            return readableRepository;
        }
    }
}
