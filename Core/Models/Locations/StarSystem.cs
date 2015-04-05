// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StarSystem.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Models
{
    using System;
    using RpgTools.Core.Models.Locations;

    /// <summary>
    /// The star system.
    /// </summary>
    public class StarSystem : Location
    {
        /// <summary>
        /// Gets or sets the population.
        /// </summary>
        public int Population { get; set; }

        /// <summary>
        /// Gets or sets the sector id.
        /// </summary>
        public Guid SectorId { get; set; }

        /// <summary>
        /// Gets or sets the sector.
        /// </summary>
        public Sector Sector { get; set; }
    }
}
