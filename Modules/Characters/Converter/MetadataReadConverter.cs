// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetadataReadConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a <see cref="CharacterMetadataItem" /> stored in the database into the corresponding <see cref="Character.CharacterMetadata" /> object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;

    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="CharacterMetadataItem"/> stored in the database into the corresponding <see cref="Character.CharacterMetadata"/> object.</summary>
    internal sealed class MetadataReadConverter : IConverter<CharacterMetadataItem, Character.CharacterMetadata>
    {
        /// <summary>The tags converter.</summary>
        private readonly IConverter<string, IEnumerable<Tag>> tagsConverter;

        /// <summary>The occurrences converter.</summary>
        private readonly IConverter<string, IEnumerable<Guid>> occurrencesConverter;

        /// <summary>Initializes a new instance of the <see cref="MetadataReadConverter"/> class.</summary>
        public MetadataReadConverter()
            : this(new TagsReadConverter(), new OccourrencesReadConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MetadataReadConverter"/> class.</summary>
        /// <param name="tagsConverter">The tags converter.</param>
        /// <param name="occurrencesConverter">The occurrences converter.</param>
        internal MetadataReadConverter(IConverter<string, IEnumerable<Tag>> tagsConverter, IConverter<string, IEnumerable<Guid>> occurrencesConverter)
        {
            this.tagsConverter = tagsConverter;
            this.occurrencesConverter = occurrencesConverter;
        }

        /// <inheritdoc/>
        public Character.CharacterMetadata Convert(CharacterMetadataItem value)
        {
            Character.CharacterMetadata metadata = new Character.CharacterMetadata
            {
                VoiceActor = value.VoiceActor
            };

            string tags = value.Tags;
            if (!string.IsNullOrEmpty(tags) && !string.IsNullOrWhiteSpace(tags))
            {
                metadata.Tags = this.tagsConverter.Convert(tags);
            }

            string occurrences = value.Occurrences;
            if (!string.IsNullOrEmpty(occurrences) && !string.IsNullOrWhiteSpace(occurrences))
            {
                metadata.Occurrences = this.occurrencesConverter.Convert(occurrences);
            }

            return metadata;
        }
    }
}