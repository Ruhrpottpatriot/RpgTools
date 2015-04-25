// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppearanceConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a <see cref="Character.PhysicalAppearance" /> to an <see cref="AppearanceDataContract" /> for storage in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="Character.PhysicalAppearance"/> to an <see cref="AppearanceDataContract"/> for storage in the database.</summary>
    internal sealed class AppearanceConverter : IConverter<Character.PhysicalAppearance, AppearanceDataContract>
    {
        /// <summary>Holds a reference to the genders converter.</summary>
        private readonly IConverter<Character.PhysicalAppearance.Genders, int> gendersConverter;

        /// <summary>Initialises a new instance of the <see cref="AppearanceConverter"/> class.</summary>
        public AppearanceConverter()
            : this(new GendersConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="AppearanceConverter"/> class.</summary>
        /// <param name="gendersConverter">The genders converter.</param>
        internal AppearanceConverter(IConverter<Character.PhysicalAppearance.Genders, int> gendersConverter)
        {
            this.gendersConverter = gendersConverter;
        }

        /// <inheritdoc /> 
        public AppearanceDataContract Convert(Character.PhysicalAppearance value)
        {
            AppearanceDataContract dataContract = new AppearanceDataContract
                                                  {
                                                      Bust = value.Bust,
                                                      CupSize = value.CupSize,
                                                      EyeColour = value.EyeColour,
                                                      Gender = this.gendersConverter.Convert(value.Gender),
                                                      HairColour = value.HairColour,
                                                      Height = value.Height,
                                                      HeterochromiaIridum = value.HeterochromiaIridum,
                                                      Hip = value.Hip,
                                                      LipColour = value.LipColour,
                                                      SkinColour = value.SkinColour,
                                                      Waist = value.Waist,
                                                      Weight = value.Weight
                                                  };

            return dataContract;
        }
    }
}