// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetadataReadConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the MetadataReadConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="MetadataDatabaseItem"/> into the corresponding <see cref="Character.CharacterMetadata"/> item.</summary>
    internal sealed class MetadataReadConverter : IConverter<MetadataDatabaseItem, Character.CharacterMetadata>
    {
        /// <summary>Holds a reference to the tags converter.
        /// </summary>
        private readonly IConverter<string, IEnumerable<string>> tagsConverter;

        /// <summary>Holds a reference to the occurrences converter.</summary>
        private readonly IConverter<string, IEnumerable<Guid>> occurrencesConverter;

        /// <summary>Initialises a new instance of the <see cref="MetadataReadConverter"/> class.</summary>
        public MetadataReadConverter()
            : this(new OccurrencesReadConverter(), new TagsReadConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="MetadataReadConverter"/> class.</summary>
        /// <param name="occurrencesConverter">The converter used to convert a semi-colon separated list of <see cref="Guid">Guids</see> into a list of guids.</param>
        /// <param name="tagsConverter">The converter used to convert a semi-colon separated tag string into a list of tags.</param>
        internal MetadataReadConverter(IConverter<string, IEnumerable<Guid>> occurrencesConverter, IConverter<string, IEnumerable<string>> tagsConverter)
        {
            this.occurrencesConverter = occurrencesConverter;
            this.tagsConverter = tagsConverter;
        }

        /// <inheritdoc />
        public Character.CharacterMetadata Convert(MetadataDatabaseItem value)
        {
            return new Character.CharacterMetadata
            {
                Tags = this.tagsConverter.Convert(value.Tags),
                Occourrences = this.occurrencesConverter.Convert(value.Occurrences),
                VoiceActor = value.VoiceActor
            };
        }
    }
}