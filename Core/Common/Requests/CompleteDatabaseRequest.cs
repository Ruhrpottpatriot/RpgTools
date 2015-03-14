namespace RpgTools.Core.Common.Requests
{
    using System;
    using System.Data.Entity;

    /// <summary>Base class for all requests that target a <see cref="DbSet"/>.</summary>
    /// <typeparam name="TContext">The database context to query.</typeparam>
    /// <typeparam name="TData">The type of data to return.</typeparam>
    public abstract class CompleteDatabaseRequest<TContext, TData> : ICompleteDatabaseRequest<TContext, TData>
    {
        public abstract Func<TContext, TData> Resource { get; }
    }
}