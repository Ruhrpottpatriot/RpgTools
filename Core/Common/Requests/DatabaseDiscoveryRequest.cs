// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseDiscoveryRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Base class for all discovery requests against a database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    using System;

    /// <summary>Base class for all discovery requests against a database.</summary>
    /// <typeparam name="TContext">The database context to query.</typeparam>
    /// <typeparam name="TReturn">The type of the data that is returned.</typeparam>
    public abstract class DatabaseDiscoveryRequest<TContext, TReturn> : IDatabaseDiscoveryRequest<TContext, TReturn>
    {
        /// <inheritdoc />
        public abstract Func<TContext, TReturn> Resource { get; }
    }
}