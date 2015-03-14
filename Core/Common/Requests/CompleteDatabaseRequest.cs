// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompleteDatabaseRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Base class for all requests that target a <see cref="DbSet" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    using System;
    using System.Data.Entity;

    /// <summary>Base class for all requests that target a <see cref="DbSet"/>.</summary>
    /// <typeparam name="TContext">The database context to query.</typeparam>
    /// <typeparam name="TData">The type of data to return.</typeparam>
    public abstract class CompleteDatabaseRequest<TContext, TData> : IDatabaseCompleteRequest<TContext, TData>
    {
        public abstract Func<TContext, TData> Resource { get; }
    }
}