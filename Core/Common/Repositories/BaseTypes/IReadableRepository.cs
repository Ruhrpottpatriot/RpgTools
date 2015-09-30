// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IReadableRepository.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System.Collections.Generic;

    /// <summary>Provides the interface for queries against a data source.</summary>
    /// <typeparam name="TKey">The type of the key values that uniquely identify the entities in the repository.</typeparam>
    /// <typeparam name="TValue">The type of the entities in the repository.</typeparam>
    public interface IReadableRepository<TKey, TValue>
    {
        /// <summary>Retrieves a given object of <see cref="TValue"/> from the data source.</summary>
        /// <param name="identifier">The object identifier.</param>
        /// <returns>An object of <see cref="TValue"/>.</returns>
        TValue Find(TKey identifier);

        /// <summary>Retrieves all objects of type <see cref="TValue"/> from the data source.</summary>
        /// <returns>An <see cref="IDictionaryRange{TKey,TValue}"/>. With the object id as key and the object itself as value.</returns>
        IDictionaryRange<TKey, TValue> FindAll();

        /// <summary>Retrieves a range of objects of type <see cref="TValue"/> from the data source.</summary>
        /// <param name="identifiers">A <see cref="ICollection{T}"/> with keys of type <see cref="TKey"/> to retrieve.</param>
        /// <returns>An <see cref="IDictionaryRange{TKey,TValue}"/> with the object id as key and the object itself as value.</returns>
        IDictionaryRange<TKey, TValue> FindAll(ICollection<TKey> identifiers);
    }
}
