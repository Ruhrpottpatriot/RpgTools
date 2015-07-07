// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CityReadConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts the <see cref="LocationDetailsDataContract"/> into an object of type <see cref="City"/>.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts the <see cref="LocationDetailsDataContract"/> into an object of type <see cref="City"/>.</summary>
    internal sealed class CityReadConverter : IConverter<LocationDetailsDataContract, City>
    {
        /// <inheritdoc />
        public City Convert(LocationDetailsDataContract value)
        {
            if (value == null)
            {
                return new City();
            }

            var details = (CityDetailsDataContract)value;

            return new City
                   {
                       Population = details.Population,
                       IsCapital = details.IsCapital,
                       PlanetId = details.Planet
                   };
        }
    }
}