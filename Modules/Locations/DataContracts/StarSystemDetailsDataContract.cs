// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StarSystemDetailsDataContract.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The system details.
    /// </summary>
    [Table("StarSystemDetails")]
    internal class StarSystemDetailsDataContract : LocationDetailsDataContract
    {
        /// <summary>
        /// Gets or sets the sector.
        /// </summary>
        public Guid Sector { get; set; }

        /// <summary>
        /// Gets or sets the population.
        /// </summary>
        public int Population { get; set; }
    }
}
