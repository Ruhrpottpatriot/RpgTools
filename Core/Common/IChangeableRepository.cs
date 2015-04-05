// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IChangeableRepository.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    /// <summary>Provides the interface that supports write operations against the repository.</summary>
    /// <typeparam name="TKey">The type of the key values that uniquely identify the entities in the repository.</typeparam>
    /// <typeparam name="TValue">The type of the entities in the repository.</typeparam>
    public interface IChangeableRepository<TKey, TValue> : IRepository<TKey, TValue>
    {
        /// <summary>Adds an entity to the repository.</summary>
        /// <param name="identifier">The entity's identifier.</param>
        /// <param name="entity">The entity to add.</param>
        void Add(TKey identifier, TValue entity);

        /// <summary>Deletes an entity from the repository.</summary>
        /// <param name="identifier">The entity's identifier.</param>
        void Delete(TKey identifier);

        /// <summary>Edits an entity.</summary>
        /// <param name="identifier">The entity's identifier.</param>
        /// <param name="updatedEntity">The updated entity.</param>
        void Edit(TKey identifier, TValue updatedEntity);
    }
}
