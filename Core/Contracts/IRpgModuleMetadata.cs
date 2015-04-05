// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRpgModuleMetadata.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines methods an properties for the rpg module metadata attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Contracts
{
    /// <summary>Defines methods an properties for the rpg module metadata attribute.</summary>
    public interface IRpgModuleMetadata
    {
        /// <summary>Gets the name.</summary>
        string Name { get; }
    }
}