// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CityLocationConverter.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations.Converter
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models.Locations;
    using RpgTools.Locations.DataContracts;

    /// <summary>Converts the <see cref="LocationDetailsDataContract"/> into an object of type <see cref="City"/>.</summary>
    internal sealed class CityLocationConverter : IConverter<LocationDetailsDataContract, City>
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