// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IReadableRepository.cs" company="Robert Logiewa">
// (C) All rights reserved.
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
    public interface IReadableRepository<TKey, TValue>
    {
        /// <summary>Retrieves a given object of <see cref="TValue"/> from the data source.</summary>
        /// <param name="identifier">The object identifier.</param>
        /// <returns>An object of <see cref="TValue"/>.</returns>
        Task<TValue> FindAsync(TKey identifier);

        /// <summary>Retrieves a given object of <see cref="TValue"/> from the data source.</summary>
        /// <param name="identifier">The object identifier.</param>
        /// <param name="cancellationToken">A token, that signals the cancellation of the operation.</param>
        /// <returns>An object of <see cref="TValue"/>.</returns>
        Task<TValue> FindAsync(TKey identifier, CancellationToken cancellationToken);

        /// <summary>Retrieves all objects of type <see cref="TValue"/> from the data source.</summary>
        /// <returns>An <see cref="IDictionaryRange{TKey,TValue}"/>. With the object id as key and the object itself as value.</returns>
        Task<IDictionaryRange<TKey, TValue>> FindAllAsync();

        /// <summary>Retrieves all objects of type <see cref="TValue"/> from the data source.</summary>
        /// <param name="cancellationToken">A token, that signals the cancellation of the operation.</param>
        /// <returns>An <see cref="IDictionaryRange{TKey,TValue}"/>. With the object id as key and the object itself as value.</returns>
        Task<IDictionaryRange<TKey, TValue>> FindAllAsync(CancellationToken cancellationToken);

        /// <summary>Retrieves a range of objects of type <see cref="TValue"/> from the data source.</summary>
        /// <param name="identifiers">A <see cref="ICollection{T}"/> with keys of type <see cref="TKey"/> to retrieve.</param>
        /// <returns>An <see cref="IDictionaryRange{TKey,TValue}"/> with the object id as key and the object itself as value.</returns>
        Task<IDictionaryRange<TKey, TValue>> FindAllAsync(ICollection<TKey> identifiers);

        /// <summary>Retrieves a range of objects of type <see cref="TValue"/> from the data source.</summary>
        /// <param name="identifiers">A <see cref="ICollection{T}"/> with keys of type <see cref="TKey"/> to retrieve.</param>
        /// <param name="cancellationToken">A token, that signals the cancellation of the operation.</param>
        /// <returns>An <see cref="IDictionaryRange{TKey,TValue}"/> with the object id as key and the object itself as value.</returns>
        Task<IDictionaryRange<TKey, TValue>> FindAllAsync(ICollection<TKey> identifiers, CancellationToken cancellationToken);
    }
}
