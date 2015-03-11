// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sector.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Reprensets a sector.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Models.Locations
{
    using System.Collections.Generic;

    /// <summary>Represents a sector.</summary>
    public class Sector : Location
    {
        /// <summary>Gets or sets the planets in the sector.</summary>
        public virtual ICollection<Planet> Planets { get; set; }

        /// <summary>Gets or sets the number of inhabitants.</summary>
        public int Inhabitants { get; set; }
    }
}