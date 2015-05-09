// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppearanceReadConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   The appearance database response converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="AppearanceDatabaseItem"/> into the corresponding <see cref="Character.PhysicalAppearance"/> item.</summary>
    internal sealed class AppearanceReadConverter : IConverter<AppearanceDatabaseItem, Character.PhysicalAppearance>
    {
        /// <summary>Stores a reference to the gender converter.
        /// </summary>
        private readonly IConverter<int, Character.PhysicalAppearance.Genders> genderConverter;

        /// <summary>Initialises a new instance of the <see cref="AppearanceReadConverter"/> class.</summary>
        public AppearanceReadConverter()
            : this(new GenderReadConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="AppearanceReadConverter"/> class.</summary>
        /// <param name="genderConverter">The converter used to convert the database stored value into the appropriate gender.</param>
        internal AppearanceReadConverter(IConverter<int, Character.PhysicalAppearance.Genders> genderConverter)
        {
            this.genderConverter = genderConverter;
        }

        /// <inheritdoc />
        public Character.PhysicalAppearance Convert(AppearanceDatabaseItem value)
        {
            return new Character.PhysicalAppearance
                   {
                       Bust = value.Bust,
                       CupSize = value.CupSize,
                       EyeColour = value.EyeColour,
                       Gender = this.genderConverter.Convert(value.Gender),
                       HairColour = value.HairColour,
                       Height = value.Height,
                       HeterochromiaIridum = value.HeterochromiaIridum,
                       Hip = value.Hip,
                       LipColour = value.LipColour,
                       SkinColour = value.SkinColour,
                       Waist = value.Waist,
                       Weight = value.Weight
                   };
        }
    }
}