// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppearanceWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the AppearanceWriteConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="Character.PhysicalAppearance"/> into the appropriate <see cref="AppearanceDatabaseItem"/>.</summary>
    internal sealed class AppearanceWriteConverter : IConverter<Character.PhysicalAppearance, AppearanceDatabaseItem>
    {
        /// <summary>Holds a reference to the gender write converter.</summary>
        private readonly IConverter<Character.PhysicalAppearance.Genders, int> genderWriteConverter;

        /// <summary>Initialises a new instance of the <see cref="AppearanceWriteConverter"/> class.</summary>
        public AppearanceWriteConverter()
            : this(new GenderWriteConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="AppearanceWriteConverter"/> class.</summary>
        /// <param name="genderWriteConverter">The converter that converts the gender into a database type.</param>
        internal AppearanceWriteConverter(IConverter<Character.PhysicalAppearance.Genders, int> genderWriteConverter)
        {
            this.genderWriteConverter = genderWriteConverter;
        }

        /// <inheritdoc />
        public AppearanceDatabaseItem Convert(Character.PhysicalAppearance value)
        {
            return new AppearanceDatabaseItem
            {
                Bust = value.Bust,
                CupSize = value.CupSize,
                EyeColour = value.EyeColour,
                Gender = this.genderWriteConverter.Convert(value.Gender),
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