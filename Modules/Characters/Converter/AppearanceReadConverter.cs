// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppearanceReadConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts an <see cref="AppearanceItem" /> stored in the database into the corresponding <see cref="Character.PhysicalAppearance" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts an <see cref="AppearanceItem"/> stored in the database into the corresponding <see cref="Character.PhysicalAppearance"/>.</summary>
    internal sealed class AppearanceReadConverter : IConverter<AppearanceItem, Character.PhysicalAppearance>
    {
        /// <summary>The heterochromia iridum read converter.</summary>
        private readonly IConverter<string, bool> heterochromiaIridumConverter;

        /// <summary>Initialises a new instance of the <see cref="AppearanceReadConverter"/> class.</summary>
        public AppearanceReadConverter()
            : this(new HeterochromiaIridumReadConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="AppearanceReadConverter"/> class.</summary>
        /// <param name="specialFeaturesConverter">The converter which extracts a boolean value from the special features list indicating, whether a character has Heterochromia Iridum.</param>
        internal AppearanceReadConverter(IConverter<string, bool> specialFeaturesConverter)
        {
            this.heterochromiaIridumConverter = specialFeaturesConverter;
        }

        /// <inheritdoc/>
        public Character.PhysicalAppearance Convert(AppearanceItem value)
        {
            Character.PhysicalAppearance appearance = new Character.PhysicalAppearance
            {
                Bust = value.Bust,
                CupSize = value.CupSize,
                EyeColour = value.EyeColour,
                Gender = value.Gender,
                HairColour = value.HairColour,
                Height = value.Height,
                Hip = value.Hip,
                LipColour = value.LipColour,
                SkinColour = value.SkinColour,
                Waist = value.Waist,
                Weight = value.Weight
            };

            string specialFeatures = value.SpecialFeatures;
            if (!string.IsNullOrEmpty(specialFeatures) && !string.IsNullOrWhiteSpace(specialFeatures))
            {
                appearance.HeterochromiaIridum = this.heterochromiaIridumConverter.Convert(specialFeatures);
            }

            return appearance;
        }
    }
}