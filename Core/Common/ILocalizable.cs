// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILocalizable.cs" company="Robert Logiewa">
// (C) All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System.Globalization;

    /// <summary>Provides the interface for locale-aware types.</summary>
    public interface ILocalizable
    {
        /// <summary>Gets or sets the culture.</summary>
        CultureInfo Culture { get; set; }
    }
}