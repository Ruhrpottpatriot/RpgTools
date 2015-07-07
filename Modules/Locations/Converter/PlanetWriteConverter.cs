// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanetWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts an object of type <see cref="LocationDetailsDataContract"/> into an object of type <see cref="Planet"/>.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts an object of type <see cref="LocationDetailsDataContract"/> into an object of type <see cref="Planet"/>.</summary>
    internal class PlanetWriteConverter : IConverter<Location, LocationDetailsDataContract>
    {
        /// <inheritdoc />
        public LocationDetailsDataContract Convert(Location value)
        {
            Planet data = (Planet)value;

            return new PlanetDetailsDataContract
                       {
                           Id = data.Id, 
                           Population = data.Population, 
                           System = data.SystemId
                       };
        }
    }
}