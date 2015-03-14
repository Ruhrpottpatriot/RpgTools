namespace RpgTools.Core.Common.Requests
{
    /// <summary>Provides the interface for a complete database context query.</summary>
    /// <typeparam name="TContext">The database context to query.</typeparam>
    /// <typeparam name="TData">The type of data to return.</typeparam>
    public interface ICompleteDatabaseRequest<in TContext, out TData> : IDatabaseRequest<TContext, TData>
    {
    }
}