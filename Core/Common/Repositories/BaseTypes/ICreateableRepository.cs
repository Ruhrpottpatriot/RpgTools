namespace RpgTools.Core.Common
{
    /// <summary>Provides the interface to create data in the repository.</summary>
    /// <typeparam name="TData">The type of data to create.</typeparam>
    public interface ICreateableRepository<TData>
    {
        /// <summary>Creates a new item in the repository.</summary>
        /// <param name="data">The data to write to the repository.</param>
        void Create(IDataContainer<TData> data);
    }
}