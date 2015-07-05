// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Robert Logiewa">
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
        TValue Find(TKey identifier);

        IDictionaryRange<TKey, TValue> FindAll();

        IDictionaryRange<TKey, TValue> FindAll(ICollection<TKey> identifiers);
    }
}
