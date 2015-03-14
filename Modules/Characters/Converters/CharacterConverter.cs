// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterConverter.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the CharacterConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Characters.Converters
{
    using System;

    using Characters.DataContracts;

    using RpgTools.Core.Common;
    using RpgTools.Core.Models.Characters;

    /// <summary>Converts a <see cref="CharacterDataContract"/> into a <see cref="Character"/>.</summary>
    internal sealed class CharacterConverter : IConverter<CharacterDataContract, Character>
    {
        /// <inheritdoc />
        public Character Convert(CharacterDataContract value)
        {
            var character = new Character(value.Id)
                                {
                                    Age = value.Age,
                                    Appearance = new Character.PhysicalAppearance
                                            {
                                                Face = new Character.PhysicalAppearance.CharacterFace
                                                        {
                                                            EyeColour = value.Appearance.EyeColour,
                                                            HairColour = value.Appearance.HairColour,
                                                            HeterochromiaIridum = value.Appearance.HeterochromiaIridum,
                                                            LipColour = value.Appearance.LipColour
                                                        },
                                                Gender = (Character.PhysicalAppearance.Genders)Enum.Parse(typeof(Character.PhysicalAppearance.Genders), value.Appearance.Gender),
                                                Height = value.Appearance.Height,
                                                Measurements = new Character.PhysicalAppearance.FemaleMeasurements
                                                    {
                                                        Bust = value.Appearance.Bust,
                                                        CupSize = value.Appearance.CupSize,
                                                        Hip = value.Appearance.Hip,
                                                        Waist = value.Appearance.Waist
                                                    },
                                                SkinColour = value.Appearance.SkinColour
                                            },
                                    Metadata = new Character.CharacterMetadata(value.Id)
                                                   {
                                                       IsAlive = value.IsAlive != null && (bool)value.IsAlive,
                                                       Tags = value.Tags,
                                                       VoiceActor = value.VoiceActor
                                                   },
                                    Motto = value.Motto,
                                    Name = value.Name,
                                    Nickname = value.Nickname,
                                    Portrait = value.Portrait,
                                    Title = value.Title
                                };

            return character;
        }
    }
}