// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenderReadConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the GenderReadConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a database stored gender into the appropriate <see cref="Character.PhysicalAppearance.Genders"/>
    /// </summary>
    internal sealed class GenderReadConverter : IConverter<int, Character.PhysicalAppearance.Genders>
    {
        /// <inheritdoc />
        public Character.PhysicalAppearance.Genders Convert(int value)
        {
            return (Character.PhysicalAppearance.Genders)value;
        }
    }
}