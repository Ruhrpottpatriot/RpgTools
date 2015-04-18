// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tag.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the Tag type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Models
{
    using System;
    using System.Globalization;
    using RpgTools.Core.Common;

    /// <summary>Describes a tag used by the tool.</summary>
    public class Tag : ILocalizable
    {
        /// <summary>Gets ot sets the id.</summary>
        public Guid Id { get; set; }
        
        /// <summary>Gets or sets the value.</summary>
        public string Value { get; set; }

        /// <summary>Gets or sets the tags type.</summary>
        public string Type { get; set; }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }
    }
}
