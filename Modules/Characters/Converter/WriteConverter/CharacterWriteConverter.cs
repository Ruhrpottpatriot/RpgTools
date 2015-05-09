// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the CharacterWriteConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="Character"/> into the appropriate <see cref="CharacterDatabaseItem" /></summary>
    internal sealed class CharacterWriteConverter : IConverter<Character, CharacterDatabaseItem>
    {
        /// <summary>Holds a reference to the appearance converter.</summary>
        private readonly IConverter<Character.PhysicalAppearance, AppearanceDatabaseItem> appearanceConverter;

        /// <summary>Holds a reference to the metadata converter.</summary>
        private readonly IConverter<Character.CharacterMetadata, MetadataDatabaseItem> metadataConverter;

        /// <summary>Initialises a new instance of the <see cref="CharacterWriteConverter"/> class.</summary>
        public CharacterWriteConverter()
            : this(new MetadataWriteConverter(), new AppearanceWriteConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="CharacterWriteConverter"/> class.</summary>
        /// <param name="metadataConverter">The converter that converts a <see cref="Character.CharacterMetadata"/> for database storage.</param>
        /// <param name="appearanceConverter">The converter that converts a <see cref="Character.PhysicalAppearance"/> for database storage.</param>
        internal CharacterWriteConverter(IConverter<Character.CharacterMetadata, MetadataDatabaseItem> metadataConverter, IConverter<Character.PhysicalAppearance, AppearanceDatabaseItem> appearanceConverter)
        {
            this.metadataConverter = metadataConverter;
            this.appearanceConverter = appearanceConverter;
        }

        /// <inheritdoc />
        public CharacterDatabaseItem Convert(Character value)
        {
            CharacterDatabaseItem data = new CharacterDatabaseItem
            {
                Age = value.Age,
                Biography = value.Biography,
                Culture = value.Culture.Name,
                Id = value.Id,
                Description = value.Description,
                Motto = value.Motto,
                Name = value.Name,
                Nickname = value.Nickname,
                OriginId = value.OriginId,
                Portrait = value.Portrait,
                Title = value.Title
            };

            Character.PhysicalAppearance appearance = value.Appearance;
            if (appearance != null)
            {
                data.AppearanceDatabaseItem = this.appearanceConverter.Convert(appearance);
            }

            Character.CharacterMetadata metadata = value.Metadata;
            if (metadata != null)
            {
                data.MetadataDatabaseItem = this.metadataConverter.Convert(metadata);
            }

            return data;
        }
    }
}