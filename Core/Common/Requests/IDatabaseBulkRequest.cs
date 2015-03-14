// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDatabaseBulkRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the IDatabaseBulkRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    using System;

    /// <summary>Provides the interface for bulk requests against a database.</summary>
    /// <typeparam name="TContext">The database context to query.</typeparam>
    /// <typeparam name="TReturn">The type of data to return.</typeparam>
    /// <typeparam name="TIdentifier">The identifier type.</typeparam>
    public interface IDatabaseBulkRequest<in TContext, out TReturn, TIdentifier> : IBulkRequest<Func<TContext, TReturn>, TIdentifier>
    {
    }
}