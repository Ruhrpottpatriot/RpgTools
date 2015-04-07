// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationDetailsDataContract.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations.DataContracts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The location details.
    /// </summary>
    internal abstract class LocationDetailsDataContract
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key, ForeignKey("Location")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public LocationDataContract Location { get; set; }
    }
}