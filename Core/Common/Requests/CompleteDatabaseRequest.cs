// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompleteDatabaseRequest.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Represents a request against a database that returns all records.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    using System;
    using System.Data.Entity;
    using System.Linq.Expressions;

    /// <summary>Represents a request against a database that returns all records.</summary>
    /// <typeparam name="TData">The type of data to return from the request.</typeparam>
    public abstract class CompleteDatabaseRequest<TData> : IDatabaseRequest<Func<DbContext, TData>>
    {
        /// <summary>Gets the resource to query.</summary>
        public abstract Expression<Func<DbContext, TData>> Resource { get; }

        /// <summary>Gets or sets the database context.</summary>
        public DbContext Context { get; set; }
    }
}