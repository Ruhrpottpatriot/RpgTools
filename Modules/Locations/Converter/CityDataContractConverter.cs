// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CityDataContractConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>
    /// The city data contract converter.
    /// </summary>
    internal sealed class CityDataContractConverter : IConverter<Location, LocationDetailsDataContract>
    {
        /// <inheritdoc />
        public LocationDetailsDataContract Convert(Location value)
        {
            City data = (City)value;

            var contract = new CityDetailsDataContract
                               {
                                   Id = data.Id, 
                                   IsCapital = data.IsCapital, 
                                   Planet = data.PlanetId, 
                                   Population = data.Population
                               };


            return contract;
        }
    }
}