// --------------------------------------------------------------------------------------------------------------------
// <copyright file="City.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Represents a city.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Models
{
    using System;
    using RpgTools.Core.Models.Locations;

    /// <summary>Represents a city.</summary>
    public class City : Location
    {
        /// <summary>Gets or sets the number of inhabitants.</summary>
        public int Population { get; set; }

        /// <summary>Gets or sets the planet id.</summary>
        public Guid PlanetId { get; set; }

        /// <summary>Gets or sets the planet the city is on.</summary>
        public Planet Planet { get; set; }

        /// <summary>Gets or sets whether the city is a capital.</summary>
        public bool? IsCapital { get; set; }
    }
}