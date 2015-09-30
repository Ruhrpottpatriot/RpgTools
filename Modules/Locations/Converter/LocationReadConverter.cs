// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationReadConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a <see cref="LocationDatabaseItem"/> into the corresponding <see cref="Location"/>.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations
{
    using System.Collections.Generic;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="LocationDatabaseItem"/> into the corresponding <see cref="Location"/>.</summary>
    internal sealed class LocationReadConverter : IConverter<LocationDatabaseItem, Location>
    {
        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<LocationDetailsDataContract, Location>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="LocationReadConverter"/> class.</summary>
        public LocationReadConverter()
        {
            this.typeConverters = GetKnowTypeConverters();
        }

        /// <inheritdoc />
        public Location Convert(LocationDatabaseItem value)
        {
            IConverter<LocationDetailsDataContract, Location> locationConverter;
            var location = this.typeConverters.TryGetValue(value.Type, out locationConverter) ? locationConverter.Convert(value.Details) : new Location();

            location.Coordinates = value.Coordinates;
            location.Description = value.Description;
            location.Id = value.Id;
            location.Name = value.Name;
            
            return location;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<LocationDetailsDataContract, Location>> GetKnowTypeConverters()
        {
            return new Dictionary<string, IConverter<LocationDetailsDataContract, Location>>
            {
                { "City", new CityReadConverter() }, 
                { "Planet", new PlanetReadConverter() }, 
                { "System", new StarSystemReadConverter() }, 
                { "Sector", new SectorReadConverter() }
            };
        }
    }
}