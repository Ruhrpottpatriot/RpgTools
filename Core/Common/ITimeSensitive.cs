// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITimeSensitive.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides the interface for types whose value is time sensitive.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System;

    /// <summary>Provides the interface for types whose value is time sensitive.</summary>
    public interface ITimeSensitive
    {
        /// <summary>Gets or sets a timestamp.</summary>
        DateTimeOffset? Timestamp { get; set; }
    }
}