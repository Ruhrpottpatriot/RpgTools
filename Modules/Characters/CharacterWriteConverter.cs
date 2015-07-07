// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a <see cref="Character" /> into the corresponding <see cref="Character" /> for storage in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="Character"/> into the corresponding <see cref="Character"/> for storage in the database.</summary>
    internal sealed class CharacterWriteConverter : IConverter<Character, CharacterItem>
    {
        /// <summary>Converts the given object of type <typeparamref name="TInput"/> to an object of type <typeparamref name="TOutput"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public CharacterItem Convert(Character value)
        {
            throw new System.NotImplementedException();
        }
    }
}