// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterReadConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a <see cref="CharacterItem" /> stored in the database into the corresponding <see cref="Character" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="CharacterItem"/> stored in the database into the corresponding <see cref="Character"/>.</summary>
    internal sealed class CharacterReadConverter : IConverter<CharacterItem, Character>
    {
        /// <inheritdoc/>
        public Character Convert(CharacterItem value)
        {
            throw new System.NotImplementedException();
        }
    }
}