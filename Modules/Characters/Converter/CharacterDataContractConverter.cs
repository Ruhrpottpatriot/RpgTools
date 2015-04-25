// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterDataContractConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the CharacterDataContractConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System.Diagnostics.Contracts;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    internal sealed class CharacterDataContractConverter : IConverter<CharacterDataContract, Character>
    {
        private readonly IConverter<AppearanceDataContract, Character.PhysicalAppearance> appearanceConverter;

        private readonly IConverter<MetadataDataContract, Character.CharacterMetadata> metadataConverter;

        public CharacterDataContractConverter()
            :this(new AppearanceDataContractConverter(), new MetadataDataContractConverter())
        {
        }

        internal CharacterDataContractConverter(IConverter<AppearanceDataContract, Character.PhysicalAppearance> appearanceConverter, IConverter<MetadataDataContract, Character.CharacterMetadata> metadataConverter)
        {
            this.appearanceConverter = appearanceConverter;
            this.metadataConverter = metadataConverter;
        }

        /// <summary>Converts the given object of type <typeparamref name="TInput"/> to an object of type <typeparamref name="TOutput"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Character Convert(CharacterDataContract value)
        {
            Contract.Assume(value != null);

            Character character = new Character(value.Id)
            {
                Age = value.Age,
                Motto = value.Motto,
                Name = value.Name,
                Nickname = value.Nickname,
                OriginId = value.OriginId,
                Portrait = value.Portrait,
                ShortDescription = value.ShortDescription,
                Title = value.Title
            };

            AppearanceDataContract appearance = value.Appearance;
            if (appearance != null)
            {
                character.Appearance = this.appearanceConverter.Convert(appearance);
            }

            MetadataDataContract metadata = value.Metadata;
            if (metadata != null)
            {
                character.Metadata = this.metadataConverter.Convert(metadata);
            }

            return character;
        }
    }
}