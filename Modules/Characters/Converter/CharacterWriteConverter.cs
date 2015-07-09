// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a <see cref="Character" /> into the corresponding <see cref="Character" /> for storage in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="Character"/> into the corresponding <see cref="Character"/> for storage in the database.</summary>
    internal sealed class CharacterWriteConverter : IConverter<Character, CharacterItem>
    {
        /// <summary>The appearance converter.</summary>
        private readonly IConverter<Character.PhysicalAppearance, AppearanceItem> appearanceConverter;

        /// <summary>The metadata converter.</summary>
        private readonly IConverter<Character.CharacterMetadata, CharacterMetadataItem> metadataConverter;

        /// <summary>Initialises a new instance of the <see cref="CharacterWriteConverter"/> class.</summary>
        public CharacterWriteConverter()
            : this(new AppearanceWriteConverter(), new MetadataWriteConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="CharacterWriteConverter"/> class.</summary>
        /// <param name="appearanceConverter">The appearance converter.</param>
        /// <param name="metadataConverter">The metadata converter.</param>
        internal CharacterWriteConverter(IConverter<Character.PhysicalAppearance, AppearanceItem> appearanceConverter, IConverter<Character.CharacterMetadata, CharacterMetadataItem> metadataConverter)
        {
            this.appearanceConverter = appearanceConverter;
            this.metadataConverter = metadataConverter;
        }

        /// <inheritdoc/>
        public CharacterItem Convert(Character value)
        {
            CharacterItem item = new CharacterItem
            {
                Id = value.Id,
                Name = value.Name,
                OriginId = value.OriginId, // ToDo: Replace once origins are properly in place.
                Description = value.Description,
                Nickname = value.Nickname,
                Age = value.Age,
                Biography = value.Biography,
                Motto = value.Motto,
                Title = value.Title
            };

            Character.PhysicalAppearance appearance = value.Appearance;
            if (appearance != null)
            {
                item.Appearance = this.appearanceConverter.Convert(appearance);
            }

            Character.CharacterMetadata metadata = value.Metadata;
            if (metadata != null)
            {
                item.Metadata = this.metadataConverter.Convert(metadata);
            }

            return item;
        }
    }
}