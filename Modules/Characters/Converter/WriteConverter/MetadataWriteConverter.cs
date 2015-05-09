// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetadataWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the MetadataWriteConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts the <see cref="Character.CharacterMetadata"/> into the appropriate <see cref="MetadataDatabaseItem"/>.</summary>
    internal sealed class MetadataWriteConverter : IConverter<Character.CharacterMetadata, MetadataDatabaseItem>
    {
        /// <summary>Holds a reference to the tags converter.</summary>
        private readonly IConverter<IEnumerable<string>, string> tagsWriteConverter;

        /// <summary>Holds a reference to the occurrences converter.</summary>
        private readonly IConverter<IEnumerable<Guid>, string> occurrenceWriteConverter;

        /// <summary>Initialises a new instance of the <see cref="MetadataWriteConverter"/> class.</summary>
        public MetadataWriteConverter()
            : this(new TagsWriteConverter(), new OccurrenceWriteConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="MetadataWriteConverter"/> class.</summary>
        /// <param name="tagsWriteConverter">The converter used to convert the <see cref="IEnumerable{T}"/> of <see cref="string"/> into the semi-colon separated string.</param>
        /// <param name="occurrenceWriteConverter">The converter used to convert the <see cref="IEnumerable{T}"/> of <see cref="Guid"/> into the semi-colon separated string. </param>
        internal MetadataWriteConverter(IConverter<IEnumerable<string>, string> tagsWriteConverter, IConverter<IEnumerable<Guid>, string> occurrenceWriteConverter)
        {
            this.tagsWriteConverter = tagsWriteConverter;
            this.occurrenceWriteConverter = occurrenceWriteConverter;
        }

        /// <inheritdoc />
        public MetadataDatabaseItem Convert(Character.CharacterMetadata value)
        {
            MetadataDatabaseItem metadata = new MetadataDatabaseItem
            {
                VoiceActor = value.VoiceActor
            };

            IEnumerable<string> tags = value.Tags;
            if (tags != null)
            {
                metadata.Tags = this.tagsWriteConverter.Convert(value.Tags);
            }

            IEnumerable<Guid> occurrences = value.Occourrences;
            if (occurrences != null)
            {
                metadata.Occurrences = this.occurrenceWriteConverter.Convert(value.Occourrences);
            }

            return metadata;
        }
    }
}