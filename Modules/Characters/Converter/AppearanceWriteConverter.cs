// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppearanceWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts an <see cref="Character.PhysicalAppearance" /> object into the corresponding <see cref="AppearanceItem" /> for storage in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System.Text;

    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts an <see cref="Character.PhysicalAppearance"/> object into the corresponding <see cref="AppearanceItem"/> for storage in the database.</summary>
    internal sealed class AppearanceWriteConverter : IConverter<Character.PhysicalAppearance, AppearanceItem>
    {
        /// <summary>The heterochromia iridum converter.</summary>
        private readonly IConverter<bool, string> heterochromiaIridumConverter;

        /// <summary>Initializes a new instance of the <see cref="AppearanceWriteConverter"/> class.</summary>
        public AppearanceWriteConverter()
            : this(new HeterochromiaIridumWriteConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="AppearanceWriteConverter"/> class.</summary>
        /// <param name="heterochromiaIridumConverter">The heterochromia iridum converter.</param>
        internal AppearanceWriteConverter(IConverter<bool, string> heterochromiaIridumConverter)
        {
            this.heterochromiaIridumConverter = heterochromiaIridumConverter;
        }

        /// <inheritdoc/>
        public AppearanceItem Convert(Character.PhysicalAppearance value)
        {
            StringBuilder stringBuilder = new StringBuilder();

            AppearanceItem appearance = new AppearanceItem
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

            stringBuilder.Append(this.heterochromiaIridumConverter.Convert(value.HeterochromiaIridum));

            appearance.SpecialFeatures = stringBuilder.ToString();

            return appearance;
        }
    }
}