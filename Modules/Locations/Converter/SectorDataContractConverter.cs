// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SectorDataContractConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>
    /// The sector data contract converter.
    /// </summary>
    internal class SectorDataContractConverter : IConverter<Location, LocationDetailsDataContract>
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