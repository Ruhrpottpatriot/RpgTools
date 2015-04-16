// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sector.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Reprensets a sector.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>Represents a sector.</summary>
    public class Sector : Location
    {
        /// <summary>Gets or sets the planets in the sector.</summary>
        public virtual ICollection<Planet> Planets { get; set; }

        /// <summary>Gets or sets the planet guids.</summary>
        public virtual ICollection<Guid> PlanetGuids { get; set; }

        /// <summary>Gets or sets the number of inhabitants.</summary>
        public int Population { get; set; }
    }
}