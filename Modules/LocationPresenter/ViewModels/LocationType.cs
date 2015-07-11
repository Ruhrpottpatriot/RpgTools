// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationType.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the LocationType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.LocationPresenter.ViewModels
{
    /// <summary>Enumerates the types a location can have.</summary>
    public enum LocationType
    {
        /// <summary>Represents a city.</summary>
        City,

        /// <summary>Represents a planet.</summary>
        Planet,

        /// <summary>Represents a star system.</summary>
        StarSystem,

        /// <summary>Represents a sector.</summary>
        Sector
    }
}