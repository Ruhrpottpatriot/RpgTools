// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanetReadConverter.cs" company="Robert Logiewa">
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
    internal sealed class PlanetReadConverter : IConverter<LocationDetailsDataContract, Planet>
    {
        /// <inheritdoc />
        public Planet Convert(LocationDetailsDataContract value)
        {
            if (value == null)
            {
                return new Planet();
            }

            var data = (PlanetDetailsDataContract)value;

            return new Planet
                       {
                           Population = data.Population, 
                           SystemId = data.System
                       };
        }
    }
}