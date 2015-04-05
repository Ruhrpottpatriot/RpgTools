// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SectorDetailsDataContract.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations.DataContracts
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The sector details data contract.
    /// </summary>
    [Table("SectorDetails")]
    internal class SectorDetailsDataContract : LocationDetailsDataContract
    {
        /// <summary>
        /// Gets or sets the population.
        /// </summary>
        public int Population { get; set; }
    }
}
