// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the interface for queries against a data source.</summary>
    /// <typeparam name="TKey">The type of the key values that uniquely identify the entities in the repository.</typeparam>
    /// <typeparam name="TValue">The type of the entities in the repository.</typeparam>
    public interface IRepository<TKey, TValue>
    {
        /// <summary>Finds an object with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>An object of type <see cref="TValue"/>.</returns>
        TValue Find(TKey identifier);

        /// <summary>Finds all objects with the given identifiers</summary>
        /// <param name="identifiers">The identifiers to look for.</param>
        /// <returns>A <see cref="IDictionaryRange{TKey, TValue}"/> with the objects.</returns>
        IDictionaryRange<TKey, TValue> FindAll(ICollection<TKey> identifiers);

        /// <summary>Retrieves all objects from the database.</summary>
        /// <returns>A <see cref="IDictionaryRange{TKey, TValue}"/> with the objects.</returns>
        IDictionaryRange<TKey, TValue> FindAll();

        /// <summary>Asynchronously retrieves all objects from the database.</summary>
        /// <returns>A <see cref="IDictionaryRange{TKey, TValue}"/> with the objects.</returns>
        Task<IDictionaryRange<TKey, TValue>> FindAllAsync();

        /// <summary>Asynchronously retrieves all objects from the database.</summary>
        /// <param name="cancellationToken">The cancellation Token.</param>
        /// <returns>A <see cref="IDictionaryRange{TKey, TValue}"/> with the objects.</returns>
        Task<IDictionaryRange<TKey, TValue>> FindAllAsync(CancellationToken cancellationToken);
    }
}
