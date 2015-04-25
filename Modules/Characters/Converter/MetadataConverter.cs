// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetadataConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a <see cref="Character.CharacterMetadata" /> into the appropriate <see cref="MetadataDataContract" /> object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="Character.CharacterMetadata" /> into the appropriate <see cref="MetadataDataContract"/> object.</summary>
    internal sealed class MetadataConverter : IConverter<Character.CharacterMetadata, MetadataDataContract>
    {
        /// <summary>Holds a reference to the occurrences converter.</summary>
        private readonly IConverter<IEnumerable<Guid>, string> occurrencesConverter;

        /// <summary>Holds a reference to the tags converter.</summary>
        private readonly IConverter<IEnumerable<string>, string> tagsConverter;

        /// <summary>Initialises a new instance of the <see cref="MetadataConverter"/> class.</summary>
        public MetadataConverter()
            : this(new OccurrencesConverter(), new TagsConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="MetadataConverter"/> class.</summary>
        /// <param name="occurrencesConverter">The occurrences converter.</param>
        /// <param name="tagsConverter">The tags converter.</param>
        internal MetadataConverter(IConverter<IEnumerable<Guid>, string> occurrencesConverter, IConverter<IEnumerable<string>, string> tagsConverter)
        {
            this.occurrencesConverter = occurrencesConverter;
            this.tagsConverter = tagsConverter;
        }

        /// <inheritdoc /> 
        public MetadataDataContract Convert(Character.CharacterMetadata value)
        {
            MetadataDataContract dataContract = new MetadataDataContract
                                                {
                                                    IsAlive = value.IsAlive,
                                                    ValidDate = value.ValidDate,
                                                    VoiceActor = value.VoiceActor
                                                };

            IEnumerable<Guid> occurrences = value.Occourrences;
            if (occurrences != null)
            {
                dataContract.Occurrences = this.occurrencesConverter.Convert(occurrences);
            }

            IEnumerable<string> tags = value.Tags;
            if (occurrences != null)
            {
                dataContract.Tags = this.tagsConverter.Convert(tags);
            }

            return dataContract;
        }
    }
}