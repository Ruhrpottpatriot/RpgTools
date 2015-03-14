namespace RpgTools.Core.Common.Requests
{
    using System;

    /// <summary>Provides the interface for a complete request against a database.</summary>
    /// <typeparam name="TContext">The database context to query.</typeparam>
    /// <typeparam name="TReturn">The type of data to return.</typeparam>
    public interface IDatabaseCompleteRequest<in TContext, out TReturn> : ICompleteRequest<Func<TContext, TReturn>>
    {
    }
}