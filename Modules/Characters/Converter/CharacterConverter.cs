// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a <see cref="Character" /> into a <see cref="CharacterDataContract" /> to be stored in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="Character"/> into a <see cref="CharacterDataContract"/> to be stored in the database.</summary>
    internal sealed class CharacterConverter : IConverter<Character, CharacterDataContract>
    {
        /// <summary>Holds a reference to the appearance converter.</summary>
        private readonly IConverter<Character.PhysicalAppearance, AppearanceDataContract> appearanceConverter;

        /// <summary>Holds a reference to the metadata converter.</summary>
        private readonly IConverter<Character.CharacterMetadata, MetadataDataContract> metadataConverter;

        /// <summary>Initialises a new instance of the <see cref="CharacterConverter"/> class.</summary>
        public CharacterConverter()
            : this(new AppearanceConverter(), new MetadataConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="CharacterConverter"/> class.</summary>
        /// <param name="appearanceConverter">The appearance converter.</param>
        /// <param name="metadataConverter">The metadata converter.</param>
        internal CharacterConverter(IConverter<Character.PhysicalAppearance, AppearanceDataContract> appearanceConverter, IConverter<Character.CharacterMetadata, MetadataDataContract> metadataConverter)
        {
            this.appearanceConverter = appearanceConverter;
            this.metadataConverter = metadataConverter;
        }

        /// <inheritdoc /> 
        public CharacterDataContract Convert(Character value)
        {
            CharacterDataContract dataContract = new CharacterDataContract
                                                 {
                                                     Age = value.Age,
                                                     Id = value.Id,
                                                     Motto = value.Motto,
                                                     Name = value.Name,
                                                     Nickname = value.Nickname,
                                                     OriginId = value.OriginId,
                                                     Portrait = value.Portrait,
                                                     ShortDescription = value.ShortDescription,
                                                     Title = value.Title
                                                 };
            Character.PhysicalAppearance appearance = value.Appearance;
            if (appearance != null)
            {
                dataContract.Appearance = this.appearanceConverter.Convert(appearance);
            }

            Character.CharacterMetadata metadata = value.Metadata;
            if (metadata != null)
            {
                dataContract.Metadata = this.metadataConverter.Convert(metadata);
                dataContract.Metadata.CharacterId = value.Id;
            }

            return dataContract;
        }
    }
}