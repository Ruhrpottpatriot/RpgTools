// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StarSystemLocationConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts an object of type <see cref="LocationDetailsDataContract"/> to an object of type <see cref="StarSystem"/>.</summary>
    internal sealed class StarSystemLocationConverter : IConverter<LocationDetailsDataContract, StarSystem>
    {
        /// <inheritdoc />
        public StarSystem Convert(LocationDetailsDataContract value)
        {
            if (value == null)
            {
                return new StarSystem();
            }

            var data = (StarSystemDetailsDataContract)value;

            return new StarSystem
                       {
                           Population = data.Population, 
                           SectorId = data.Sector
                       };
        }
    }
}