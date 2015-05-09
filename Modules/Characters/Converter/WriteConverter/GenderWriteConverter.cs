// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenderWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a <see cref="Character.PhysicalAppearance.Genders" /> into a database type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="Character.PhysicalAppearance.Genders"/> into a database type.</summary>
    internal sealed class GenderWriteConverter : IConverter<Character.PhysicalAppearance.Genders, int>
    {
        /// <inheritdoc />
        public int Convert(Character.PhysicalAppearance.Genders value)
        {
            return (int)value;
        }
    }
}