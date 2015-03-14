// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DetailsDatabaseRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Base class for all detail request against a database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    using System;

    /// <summary>Base class for all detail request against a database.</summary>
    /// <typeparam name="TContext">The database context to query.</typeparam>
    /// <typeparam name="TReturn">The type of data to return.</typeparam>
    /// <typeparam name="TIdentifier">The identifier to identify the data.</typeparam>
    public abstract class DetailsDatabaseRequest<TContext, TReturn, TIdentifier> : IDetailsDatabaseRequest<TContext, TReturn, TIdentifier>
    {
        public abstract Func<TContext, TReturn> Resource { get; }

        public virtual TIdentifier Identifier { get; set; }
    }
}