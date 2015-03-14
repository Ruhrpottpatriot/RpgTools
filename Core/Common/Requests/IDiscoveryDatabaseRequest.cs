// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDiscoveryDatabaseRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides the base interface for all discovery requests against a database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    /// <summary>Provides the base interface for all discovery requests against a database.</summary>
    /// <typeparam name="TContext">The database context to query.</typeparam>
    /// <typeparam name="TReturn">The type of data to return.</typeparam>
    public interface IDiscoveryDatabaseRequest<in TContext, out TReturn> : IDatabaseRequest<TContext, TReturn>
    {
    }
}