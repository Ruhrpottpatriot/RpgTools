// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RpgModuleMetadataAttribute.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the RpgModuleMetadataAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Contracts
{
    using System;
    using System.ComponentModel.Composition;

    [MetadataAttribute]
    public class RpgModuleMetadataAttribute : Attribute
    {
        public string Name { get; set; }
    }
}