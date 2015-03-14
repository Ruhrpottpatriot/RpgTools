// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBulkDatabaseRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides the interface for bulk requests against a database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    using System.Collections.Generic;

    /// <summary>Provides the interface for bulk requests against a database.</summary>
    /// <typeparam name="TContext">The database context to query.</typeparam>
    /// <typeparam name="TData">The type of data to return.</typeparam>
    /// <typeparam name="TIdentifier">The identifier type.</typeparam>
    public interface IBulkDatabaseRequest<in TContext, out TData, TIdentifier> : IDatabaseRequest<TContext, TData>
    {
        /// <summary>Gets the identifiers.</summary>
        ICollection<TIdentifier> Identifiers { get; }
    }
}