// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BulkDatabaseRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Base class for all bulk request against a database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    using System;
    using System.Collections.Generic;

    /// <summary>Base class for all bulk request against a database.</summary>
    /// <typeparam name="TContext">The database context to query.</typeparam>
    /// <typeparam name="TData">The type of data to return.</typeparam>
    /// <typeparam name="TIdentifier">The identifier type.</typeparam>
    public abstract class BulkDatabaseRequest<TContext, TData, TIdentifier> : IDatabaseBulkRequest<TContext, TData, TIdentifier>
    {
        /// <inheritdoc />
        public abstract Func<TContext, TData> Resource { get; }

        /// <inheritdoc />
        public virtual ICollection<TIdentifier> Identifiers { get; set; }
    }
}