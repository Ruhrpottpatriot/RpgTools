// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppearanceDataContractConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the AppearanceDataContractConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts an <see cref="AppearanceDataContract"/> into the appropriate <see cref="Character.PhysicalAppearance"/>.</summary>
    internal class AppearanceDataContractConverter : IConverter<AppearanceDataContract, Character.PhysicalAppearance>
    {
        /// <summary>Holds a reference to the gender converter.</summary>
        private readonly IConverter<int, Character.PhysicalAppearance.Genders> gendersConverter;

        /// <summary>Initialises a new instance of the <see cref="AppearanceDataContractConverter"/> class.</summary>
        public AppearanceDataContractConverter()
            : this(new GenderDataContractConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="AppearanceDataContractConverter"/> class.</summary>
        /// <param name="gendersConverter">The genders converter.</param>
        public AppearanceDataContractConverter(IConverter<int, Character.PhysicalAppearance.Genders> gendersConverter)
        {
            this.gendersConverter = gendersConverter;
        }

        /// <inheritdoc /> 
        public Character.PhysicalAppearance Convert(AppearanceDataContract value)
        {
            Character.PhysicalAppearance appearance = new Character.PhysicalAppearance
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

            return appearance;
        }
    }
}