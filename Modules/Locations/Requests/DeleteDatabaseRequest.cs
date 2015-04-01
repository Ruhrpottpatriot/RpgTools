// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteDatabaseRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the DeleteDatabaseRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations
{
    using System;
    using System.Data.Entity;
    using System.Linq.Expressions;

    /// <summary>Abstract base class to delete a record from the database.</summary>
    /// <typeparam name="TDeleteData">The type of data to delete.</typeparam>
    internal abstract class DeleteDatabaseRequest<TDeleteData> : IDatabaseRequest<Action<DbContext>>
    {
        /// <summary>Gets the resource to query.</summary>
        public abstract Expression<Action<DbContext>> Resource { get; }

        /// <summary>Gets or sets the database context.</summary>
        public DbContext Context { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public TDeleteData Location { get; set; }
    }
}