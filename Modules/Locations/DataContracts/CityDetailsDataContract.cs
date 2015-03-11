// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CityDetailsDataContract.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations.DataContracts
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The city details.
    /// </summary>
    [Table("CityDetails")]
    internal class CityDetailsDataContract : LocationDetailsDataContract
    {
        /// <summary>
        /// Gets or sets the planet.
        /// </summary>
        public Guid Planet { get; set; }

        /// <summary>
        /// Gets or sets the is capital.
        /// </summary>
        public bool? IsCapital { get; set; }

        /// <summary>
        /// Gets or sets the population.
        /// </summary>
        public int Population { get; set; }
    }
}
