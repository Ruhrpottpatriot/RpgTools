// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetadataWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts an <see cref="Character.CharacterMetadata" /> object into the corresponding <see cref="CharacterMetadataItem" /> for storage in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;

    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts an <see cref="Character.CharacterMetadata"/> object into the corresponding <see cref="CharacterMetadataItem"/> for storage in the database.</summary>
    internal sealed class MetadataWriteConverter : IConverter<Character.CharacterMetadata, CharacterMetadataItem>
    {
        /// <summary>The tags converter.</summary>
        private readonly IConverter<IEnumerable<Tag>, string> tagsConverter;

        /// <summary>The occurrences converter.</summary>
        private readonly IConverter<IEnumerable<Guid>, string> occurrencesConverter;

        /// <summary>Initializes a new instance of the <see cref="MetadataWriteConverter"/> class.</summary>
        public MetadataWriteConverter()
            : this(new TagsWriteConverter(), new OccurrencesWriteConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MetadataWriteConverter"/> class.</summary>
        /// <param name="tagsConverter">The tags converter.</param>
        /// <param name="occurrencesConverter">The occurrences converter.</param>
        internal MetadataWriteConverter(IConverter<IEnumerable<Tag>, string> tagsConverter, IConverter<IEnumerable<Guid>, string> occurrencesConverter)
        {
            this.tagsConverter = tagsConverter;
            this.occurrencesConverter = occurrencesConverter;
        }

        /// <inheritdoc/>
        public CharacterMetadataItem Convert(Character.CharacterMetadata value)
        {
            CharacterMetadataItem metadata = new CharacterMetadataItem
            {
                VoiceActor = value.VoiceActor
            };

            IEnumerable<Tag> tags = value.Tags;
            if (tags != null)
            {
                metadata.Tags = this.tagsConverter.Convert(tags);
            }

            IEnumerable<Guid> occurrences = value.Occurrences;
            if (occurrences != null)
            {
                metadata.Occurrences = this.occurrencesConverter.Convert(occurrences);
            }

            return metadata;
        }
    }
}