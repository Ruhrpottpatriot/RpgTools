// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SectorWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts an object of type <see cref="Sector"/> into an object of type <see cref="LocationDetailsDataContract"/>.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts an object of type <see cref="Sector"/> into an object of type <see cref="LocationDetailsDataContract"/>.</summary>
    internal class SectorWriteConverter : IConverter<Location, LocationDetailsDataContract>
    {
        /// <inheritdoc />
        public LocationDetailsDataContract Convert(Location value)
        {
            Sector data = (Sector)value;

            return new SectorDetailsDataContract
                       {
                           Id = data.Id, 
                           Population = data.Population
                       };
        }
    }
}