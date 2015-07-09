// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterReadConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a <see cref="CharacterItem" /> stored in the database into the corresponding <see cref="Character" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="CharacterItem"/> stored in the database into the corresponding <see cref="Character"/>.</summary>
    internal sealed class CharacterReadConverter : IConverter<CharacterItem, Character>
    {
        /// <summary>The appearance converter.</summary>
        private readonly IConverter<AppearanceItem, Character.PhysicalAppearance> appearanceConverter;

        /// <summary>The metadata converter.</summary>
        private readonly IConverter<CharacterMetadataItem, Character.CharacterMetadata> metadataConverter;

        /// <summary>The portrait converter.</summary>
        private readonly IConverter<PortraitItem, byte[]> portraitConverter;

        /// <summary>Initialises a new instance of the <see cref="CharacterReadConverter"/> class.</summary>
        public CharacterReadConverter()
            : this(new AppearanceReadConverter(), new MetadataReadConverter(), new PortraitReadConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="CharacterReadConverter"/> class.</summary>
        /// <param name="appearanceConverter">The appearance converter.</param>
        /// <param name="metadataConverter">The metadata converter.</param>
        /// <param name="portraitConverter">The portrait converter.</param>
        internal CharacterReadConverter(
            IConverter<AppearanceItem, Character.PhysicalAppearance> appearanceConverter,
            IConverter<CharacterMetadataItem, Character.CharacterMetadata> metadataConverter,
            IConverter<PortraitItem, byte[]> portraitConverter)
        {
            this.appearanceConverter = appearanceConverter;
            this.metadataConverter = metadataConverter;
            this.portraitConverter = portraitConverter;
        }

        /// <inheritdoc/>
        public Character Convert(CharacterItem value)
        {
            Character character = new Character(value.Id)
            {
                Age = value.Age,
                Biography = value.Biography,
                Description = value.Description,
                Motto = value.Motto,
                Name = value.Name,
                Nickname = value.Nickname,
                Title = value.Title,
                OriginId = value.OriginId // ToDo: Replace once origins are properly in place.
            };

            AppearanceItem appearance = value.Appearance;
            if (appearance != null)
            {
                character.Appearance = this.appearanceConverter.Convert(appearance);
            }

            CharacterMetadataItem metadata = value.Metadata;
            if (metadata != null)
            {
                character.Metadata = this.metadataConverter.Convert(metadata);
            }

            PortraitItem portrait = value.Portrait;
            if (portrait != null)
            {
                character.Portrait = this.portraitConverter.Convert(portrait);
            }

            return character;
        }
    }
}