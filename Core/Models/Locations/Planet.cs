// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Planet.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Represents a planet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Models.Locations
{
    using System;
    using System.Collections.Generic;

    /// <summary>Represents a planet.</summary>
    public class Planet : Location
    {
        /// <summary>Gets or sets the number of inhabitants.</summary>
        public int Population { get; set; }

        /// <summary>
        /// Gets or sets the system id.
        /// </summary>
        public Guid SystemId { get; set; }

        /// <summary>Gets or sets the sector the planet is in.</summary>
        public Sector System { get; set; }

        /// <summary>Gets or sets the cities on the planet.</summary>
        public virtual ICollection<City> Cities { get; set; }
    }
}