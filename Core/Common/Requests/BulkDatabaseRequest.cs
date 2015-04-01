namespace RpgTools.Core.Common.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq.Expressions;

    /// <summary>Abstract base class for all bulk requests against a database.</summary>
    /// <typeparam name="TReturn">The type of data to return.</typeparam>
    public abstract class BulkDatabaseRequest<TReturn> : IDatabaseRequest<Func<DbContext, TReturn>>
    {
        /// <summary>Gets the resource to query.</summary>
        public abstract Expression<Func<DbContext, TReturn>> Resource { get; }

        /// <summary>Gets or sets the database context.</summary>
        public DbContext Context { get; set; }

        /// <summary>Gets or sets the identifiers.</summary>
        public ICollection<Guid> Identifiers { get; set; }
    }
}