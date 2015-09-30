// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a <see cref="Location"/> into the corresponding <see cref="LocationDatabaseItem"/>.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations
{
    using System.Collections.Generic;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="Location"/> into the corresponding <see cref="LocationDatabaseItem"/>.</summary>
    internal sealed class LocationWriteConverter : IConverter<Location, LocationDatabaseItem>
    {
        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly Dictionary<string, IConverter<Location, LocationDetailsDataContract>> typeConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationWriteConverter"/> class.
        /// </summary>
        public LocationWriteConverter()
        {
            this.typeConverter = GetKnownTypeConverter();
        }

        /// <inheritdoc />
        public LocationDatabaseItem Convert(Location value)
        {
            LocationDatabaseItem locationData = new LocationDatabaseItem();

            IConverter<Location, LocationDetailsDataContract> converter;

            string typeName = value.GetType().Name;

            if (this.typeConverter.TryGetValue(typeName, out converter))
            {
                locationData.Details = converter.Convert(value);
                locationData.Details.Location = locationData;
            }
            
            locationData.Coordinates = value.Coordinates;
            locationData.Description = value.Description;
            locationData.Id = value.Id;
            locationData.Name = value.Name;
            locationData.Type = value.GetType().Name;

            return locationData;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static Dictionary<string, IConverter<Location, LocationDetailsDataContract>> GetKnownTypeConverter()
        {
            return new Dictionary<string, IConverter<Location, LocationDetailsDataContract>>
            {
                { "City", new CityWriteConverter() }, 
                { "Planet", new PlanetWriteConverter() },
                { "StarSystem", new StarSystemWriteConverter() },
                { "Sector", new SectorWriteConverter() }
            };
        }
    }
}