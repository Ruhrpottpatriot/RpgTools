// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanetDetailsDataContract.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations.DataContracts
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The planet details data contract.
    /// </summary>
    [Table("PlanetDetails")]
    internal class PlanetDetailsDataContract : LocationDetailsDataContract
    {
        /// <summary>
        /// Gets or sets the sector.
        /// </summary>
        public Guid System { get; set; }

        /// <summary>
        /// Gets or sets the population.
        /// </summary>
        public int Population { get; set; }
    }
}
