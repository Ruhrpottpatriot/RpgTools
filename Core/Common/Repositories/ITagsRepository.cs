// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITagsRepository.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Core.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RpgTools.Core.Models;

    /// <summary>Provides the interface for tags repositories.</summary>
    public interface ITagsRepository : IRepository<Guid, Tag>, ILocalizable, IWriteable<Tag>
    {
        IDictionaryRange<Guid, Tag> FindByType(string type);
    }
}
