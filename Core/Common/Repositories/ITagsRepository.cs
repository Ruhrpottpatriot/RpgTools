// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITagsRepository.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Core.Common
{
    using System;
    using RpgTools.Core.Models;

    /// <summary>Provides the interface for tags repositories.</summary>
    public interface ITagsRepository : IReadableRepository<Guid, Tag>, ILocalizable, ICreateableRepository<Tag>, IUpdateableRepository<Tag>, IDeletableRepository<Guid>
    {
        /// <summary>Retrieves all objects based on a certain type.</summary>
        /// <param name="type">The type of the object to retrieve.</param>
        /// <returns>A <see cref="IDictionaryRange{TKey, TValue}"/> with the objects.</returns>
        IDictionaryRange<Guid, Tag> FindByType(string type);
    }
}
