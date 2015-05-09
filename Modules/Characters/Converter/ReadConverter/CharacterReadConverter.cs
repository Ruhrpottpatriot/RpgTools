// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterReadConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the CharacterReadConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts <see cref="CharacterDatabaseItem"/> into the corresponding <see cref="Character"/> item.</summary>
    internal sealed class CharacterReadConverter : IConverter<CharacterDatabaseItem, Character>
    {
        /// <summary>Stores a reference to the appearance converter.</summary>
        private readonly IConverter<AppearanceDatabaseItem, Character.PhysicalAppearance> appearanceConverter;

        /// <summary>Stores are reference to the metadata converter.</summary>
        private readonly IConverter<MetadataDatabaseItem, Character.CharacterMetadata> metadataConverter;
        
        /// <summary>Initialises a new instance of the <see cref="CharacterReadConverter"/> class.</summary>
        public CharacterReadConverter()
            : this(new AppearanceReadConverter(), new MetadataReadConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="CharacterReadConverter"/> class.</summary>
        /// <param name="appearanceConverter">A converter that converts a <see cref="AppearanceDatabaseItem"/> into the corresponding <see cref="Character.PhysicalAppearance"/>.</param>
        /// <param name="metadataConverter">A converter that converts a <see cref="MetadataDatabaseItem"/> into the corresponding <see cref="Character.CharacterMetadata"/>.</param>
        public CharacterReadConverter(IConverter<AppearanceDatabaseItem, Character.PhysicalAppearance> appearanceConverter, IConverter<MetadataDatabaseItem, Character.CharacterMetadata> metadataConverter)
        {
            this.appearanceConverter = appearanceConverter;
            this.metadataConverter = metadataConverter;
        }

        /// <inheritdoc />
        public Character Convert(CharacterDatabaseItem value)
        {
            Character character = new Character(value.Id)
            {
                Age = value.Age,
                Motto = value.Motto,
                Name = value.Name,
                Nickname = value.Nickname,
                OriginId = value.OriginId,
                Portrait = value.Portrait,
                Description = value.Description,
                Title = value.Title
            };

            var appearance = value.AppearanceDatabaseItem;
            if (appearance != null)
            {
                character.Appearance = this.appearanceConverter.Convert(appearance);
            }

            var metadata = value.MetadataDatabaseItem;
            if (metadata != null)
            {
                character.Metadata = this.metadataConverter.Convert(metadata);
            }

            return character;
        }
    }
}
