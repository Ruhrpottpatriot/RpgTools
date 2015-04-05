// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISubsetContext.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Provides the interface to represent information about a range of items.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    /// <summary>Provides the interface to represent information about a range of items.</summary>
    public interface ISubsetContext
    {
        /// <summary>Gets or sets the subtotal count.</summary>
        int SubtotalCount { get; set; }

        /// <summary>Gets or sets the total count.</summary>
        int TotalCount { get; set; }
    }
}