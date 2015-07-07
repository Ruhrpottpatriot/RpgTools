// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CityWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a <see cref="Location"/> into the corresponding <see cref="LocationDetailsDataContract"/> for database storage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="Location"/> into the corresponding <see cref="LocationDetailsDataContract"/> for database storage.</summary>
    internal sealed class CityWriteConverter : IConverter<Location, LocationDetailsDataContract>
    {
        /// <inheritdoc />
        public LocationDetailsDataContract Convert(Location value)
        {
            City data = (City)value;

            CityDetailsDataContract contract = new CityDetailsDataContract
            {
                Id = data.Id, 
                IsCapital = data.IsCapital, 
                Planet = data.PlanetId, 
                Population = data.Population
            };

            return contract;
        }
    }
}