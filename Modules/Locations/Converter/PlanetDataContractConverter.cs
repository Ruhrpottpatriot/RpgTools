// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanetDataContractConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations.Converter
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;
    using RpgTools.Core.Models.Locations;
    using RpgTools.Locations.DataContracts;

    /// <summary>
    /// The planet data contract converter.
    /// </summary>
    internal class PlanetDataContractConverter : IConverter<Location, LocationDetailsDataContract>
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