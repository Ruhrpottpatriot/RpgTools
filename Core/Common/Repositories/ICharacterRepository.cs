// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICharacterRepository.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Provides methods and properties for a character repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System;
    using RpgTools.Core.Models;

    /// <summary>Provides methods and properties for a character repository.</summary>
    public interface ICharacterRepository : IRepository<Guid, Character>, ILocalizable, IWriteable<Character>
    {
    }
}