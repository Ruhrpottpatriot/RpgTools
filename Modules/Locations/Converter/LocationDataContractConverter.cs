// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationDataContractConverter.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations.Converter
{
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using RpgTools.Core.Common;
    using RpgTools.Core.Models.Locations;
    using RpgTools.Locations.DataContracts;

    /// <summary>Converts a <see cref="Location"/> into the corresponding <see cref="LocationDataContract"/>.</summary>
    internal sealed class LocationDataContractConverter : IConverter<Location, LocationDataContract>
    {
        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly Dictionary<string, IConverter<Location, LocationDetailsDataContract>> typeConverter;

        /// <summary>
        /// Initialises a new instance of the <see cref="LocationDataContractConverter"/> class.
        /// </summary>
        public LocationDataContractConverter()
        {
            this.typeConverter = GetKnownTypeConverter();
        }

        /// <inheritdoc />
        public LocationDataContract Convert(Location value)
        {
            LocationDataContract locationData = new LocationDataContract();

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
                           { "City", new CityDataContractConverter() }, 
                           { "Planet", new PlanetDataContractConverter() },
                           { "StarSystem", new SystemDataContractConverter() },
                           { "Sector", new SectorDataContractConverter() }
                       };
        }
    }
}