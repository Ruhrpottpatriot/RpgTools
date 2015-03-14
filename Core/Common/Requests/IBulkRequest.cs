// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBulkRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides the interface for bulk requests against a database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    using System.Collections.Generic;

    /// <summary>Provides the interface for bulk requests.</summary>
    /// <typeparam name="TData">The resource type.</typeparam>
    /// <typeparam name="TIdentifier">The identifier type.</typeparam>
    public interface IBulkRequest<out TData, TIdentifier> : IRequest<TData>
    {
        /// <summary>Gets the identifiers.</summary>
        ICollection<TIdentifier> Identifiers { get; }
    }
}