// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILocalizable.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Provides the interface for locale-aware types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System.Globalization;

    /// <summary>Provides the interface for locale-aware types.</summary>
    public interface ILocalizable
    {
        /// <summary>Gets or sets the locale.</summary>
        CultureInfo Culture { get; set; }
    }
}