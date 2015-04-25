// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GendersConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the GendersConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a gender enumeration item to its integer representation for storage.</summary>
    internal sealed class GendersConverter : IConverter<Character.PhysicalAppearance.Genders, int>
    {
        /// <inheritdoc />
        public int Convert(Character.PhysicalAppearance.Genders value)
        {
            return (int)value;
        }
    }
}