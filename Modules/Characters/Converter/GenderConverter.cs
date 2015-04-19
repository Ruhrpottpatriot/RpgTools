namespace RpgTools.Characters
{
    using System;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    internal sealed class GenderConverter : IConverter<int, Character.PhysicalAppearance.Genders>
    {
        /// <summary>Converts the given object of type <typeparamref name="TInput"/> to an object of type <typeparamref name="TOutput"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Character.PhysicalAppearance.Genders Convert(int value)
        {
            Character.PhysicalAppearance.Genders gender;

            return Enum.TryParse(value.ToString(), out gender) ? gender : Character.PhysicalAppearance.Genders.Neutral;
        }
    }
}