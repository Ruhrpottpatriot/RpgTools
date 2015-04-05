// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationDataContract.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations.DataContracts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Globalization;

    using RpgTools.Core.Common;

    /// <summary>
    /// The location data contract.
    /// </summary>
    [Table("Locations")]
    internal class LocationDataContract
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the coordinates.
        /// </summary>
        public DbGeography Coordinates { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>Gets or sets the localisation.</summary>
        public LocalisationDataContract Localisation { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        public virtual LocationDetailsDataContract Details { get; set; }
    }
}
