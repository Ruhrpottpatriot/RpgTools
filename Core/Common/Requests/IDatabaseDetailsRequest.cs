// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDatabaseDetailsRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides the interface for detail requests against a database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    using System;

    /// <summary>Provides the interface for detail requests against a database.</summary>
    /// <typeparam name="TContext">The database context to query.</typeparam>
    /// <typeparam name="TReturn">The type of data to return.</typeparam>
    /// <typeparam name="TIdentifier">The identifier type.</typeparam>
    public interface IDatabaseDetailsRequest<in TContext, out TReturn, TIdentifier> : IDetailsRequest<Func<TContext, TReturn>, TIdentifier>
    {
    }
}