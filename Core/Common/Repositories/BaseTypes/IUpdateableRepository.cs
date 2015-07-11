// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUpdateableRepository.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Provides the interface to update data in the repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    /// <summary>Provides the interface to update data in the repository.</summary>
    /// <typeparam name="TData">They type of data to update.</typeparam>
    public interface IUpdateableRepository<TData>
    {
        /// <summary>Updates an item in the repository with the given data.</summary>
        /// <param name="data">The new data to store in the repository.</param>
        void Update(IDataContainer<TData> data);
    }
}