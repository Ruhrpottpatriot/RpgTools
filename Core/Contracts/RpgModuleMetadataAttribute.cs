// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RpgModuleMetadataAttribute.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the RpgModuleMetadataAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Contracts
{
    using System;
    using System.ComponentModel.Composition;

    /// <summary>Defines properties to describe a module.</summary>
    [MetadataAttribute]
    public class RpgModuleMetadataAttribute : Attribute
    {
        /// <summary>Gets or sets the name.</summary>
        public string Name { get; set; }
    }
}