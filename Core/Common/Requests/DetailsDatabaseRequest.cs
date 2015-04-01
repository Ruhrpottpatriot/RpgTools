// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DetailsDatabaseRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the DetailsDatabaseRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    using System;
    using System.Data.Entity;
    using System.Linq.Expressions;

    /// <summary>Base class for all detail request against a database.</summary>
    /// <typeparam name="TReturn">The type of data to return.</typeparam>
    public abstract class DetailsDatabaseRequest<TReturn> : IDatabaseRequest<Func<DbContext, TReturn>>
    {
        /// <summary>Gets the resource to query.</summary>
        public abstract Expression<Func<DbContext, TReturn>> Resource { get; }

        /// <summary>Gets or sets the identifier.</summary>
        public Guid Identifier { get; set; }

        /// <summary>Gets or sets the database context.</summary>
        public DbContext Context { get; set; }
    }
}