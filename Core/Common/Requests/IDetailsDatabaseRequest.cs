// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDetailsDatabaseRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides the interface for a details request against a database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    /// <summary>Provides the interface for a details request against a database.</summary>
    /// <typeparam name="TContext">The database context to query.</typeparam>
    /// <typeparam name="TReturn">The type of data to return.</typeparam>
    /// <typeparam name="TIdentifier">The identifier to identify the data.</typeparam>
    public interface IDetailsDatabaseRequest<in TContext, out TReturn, TIdentifier> : IDatabaseRequest<TContext, TReturn>
    {
        /// <summary>Gets or sets the data identifier.</summary>
        TIdentifier Identifier { get; set; }
    }
}