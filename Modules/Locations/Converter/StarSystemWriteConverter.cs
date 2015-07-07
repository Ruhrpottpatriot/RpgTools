// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StarSystemWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts an object of type <see cref="StarSystemDetailsDataContract"/> to an object of type <see cref="LocationDetailsDataContract"/>.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts an object of type <see cref="StarSystemDetailsDataContract"/> to an object of type <see cref="LocationDetailsDataContract"/>.</summary>
    internal class StarSystemWriteConverter : IConverter<Location, LocationDetailsDataContract>
    {
        /// <inheritdoc />
        public LocationDetailsDataContract Convert(Location value)
        {
            StarSystem data = (StarSystem)value;

            return new StarSystemDetailsDataContract
                       {
                           Id = data.Id, 
                           Population = data.Population, 
                           Sector = data.SectorId
                       };
        }
    }
}