// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanetLocationConverter.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations.Converter
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models.Locations;
    using RpgTools.Locations.DataContracts;

    /// <summary>Converts an object of type <see cref="LocationDetailsDataContract"/> into an object of type <see cref="Planet"/>.</summary>
    internal sealed class PlanetLocationConverter : IConverter<LocationDetailsDataContract, Planet>
    {
        /// <inheritdoc />
        public Planet Convert(LocationDetailsDataContract value)
        {
            var data = (PlanetDetailsDataContract)value;

            return new Planet
                       {
                           Population = data.Population, 
                           SystemId = data.System
                       };
        }
    }
}