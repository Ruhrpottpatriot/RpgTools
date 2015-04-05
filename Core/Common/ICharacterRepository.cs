namespace RpgTools.Core.Common
{
    using System;
    using RpgTools.Core.Models;

    public interface ICharacterRepository : IRepository<Guid, Character>, ILocalizable, IWriteable<Character>
    {
    }
}