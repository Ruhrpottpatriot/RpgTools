// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICreateableRepository.cs" company="Robert Logiewa">
// (C) All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System.Threading.Tasks;

    /// <summary>Provides the interface to create data in the repository.</summary>
    /// <typeparam name="TData">The type of data to create.</typeparam>
    public interface ICreateableRepository<TData>
    {
        /// <summary>Creates a new item in the repository.</summary>
        /// <param name="data">The data to write to the repository.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task CreateAsync(IDataContainer<TData> data);
    }
}