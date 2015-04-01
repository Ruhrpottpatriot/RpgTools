// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDatabaseRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the DatabaseRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    using System.Data.Entity;
    using System.Linq.Expressions;

    /// <summary>Provides properties and methods for all requests against a database.</summary>
    /// <typeparam name="TExpressionType">The type of data to return.</typeparam>
    public interface IDatabaseRequest<TExpressionType> : IRequest
    {
        /// <summary>Gets the resource to query.</summary>
        Expression<TExpressionType> Resource { get; }
        
        /// <summary>Gets or sets the database context.</summary>
        DbContext Context { get; set; }
    }
}