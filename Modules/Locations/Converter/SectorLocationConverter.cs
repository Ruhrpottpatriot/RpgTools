// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SectorLocationConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts an object of type <see cref="LocationDetailsDataContract"/> into an object of type <see cref="Sector"/>.</summary>
    internal sealed class SectorLocationConverter : IConverter<LocationDetailsDataContract, Sector>
    {
        /// <inheritdoc />
        public Sector Convert(LocationDetailsDataContract value)
        {
            if (value == null)
            {
                return new Sector();
            }

            var details = (SectorDetailsDataContract)value;

            return new Sector { Population = details.Population };
        }
    }
}