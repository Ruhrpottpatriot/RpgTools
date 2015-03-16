// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationRepositoryFactory.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations
{
    using System;
    using System.Globalization;

    using RpgTools.Core.Common;

    /// <summary>Provides methods for creating repository object in specified cultures.</summary>
    public sealed class LocationRepositoryFactory
    {
        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="language">The two-letter language code.</param>
        /// <returns>A repository.</returns>
        public ILocationRepository this[string language]
        {
            get
            {
                return this.ForCulture(new CultureInfo(language));
            }
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public ILocationRepository this[CultureInfo culture]
        {
            get
            {
                return this.ForCulture(culture);
            }
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public ILocationRepository ForDefaultCulture()
        {
            return new LocationRepository();
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public ILocationRepository ForCulture(CultureInfo culture)
        {
            // ILocationRepository repository = new LocationRepository(this.serviceClient);
            // repository.Culture = culture;
            // return repository;
            throw new NotImplementedException("Multi Language Support has not yet been implemented. Use the \"ForDefaultCulture\" method instead.");
        }

        /// <summary>Creates an instance for the current system language.</summary>
        /// <returns>A repository.</returns>
        public ILocationRepository ForCurrentCulture()
        {
            return this.ForCulture(CultureInfo.CurrentCulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <returns>A repository.</returns>
        public ILocationRepository ForCurrentUiCulture()
        {
            return this.ForCulture(CultureInfo.CurrentUICulture);
        }
    }
}
