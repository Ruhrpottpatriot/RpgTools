// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemDataContractConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations.Converter
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;
    using RpgTools.Locations.DataContracts;

    /// <summary>
    /// The system data contract converter.
    /// </summary>
    internal class SystemDataContractConverter : IConverter<Location, LocationDetailsDataContract>
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