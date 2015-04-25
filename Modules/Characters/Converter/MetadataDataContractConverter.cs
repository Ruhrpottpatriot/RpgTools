// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetadataDataContractConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the MetadataDataContractConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="MetadataDataContract"/> into its appropriate <see cref="Character.CharacterMetadata"/> representation.</summary>
    internal class MetadataDataContractConverter : IConverter<MetadataDataContract, Character.CharacterMetadata>
    {
        /// <summary>Holds a reference to the tag converter.
        /// </summary>
        private readonly IConverter<string, IEnumerable<string>> tagConverter;

        /// <summary>Holds a reference to the appearances converter.
        /// </summary>
        private readonly IConverter<string, IEnumerable<Guid>> appearancesConverter;

        /// <summary>Initialises a new instance of the <see cref="MetadataDataContractConverter"/> class.</summary>
        public MetadataDataContractConverter()
            : this(new TagConverter(), new OccourcenDataContractCoverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="MetadataDataContractConverter"/> class.</summary>
        /// <param name="tagConverter">The tag converter.</param>
        /// <param name="appearancesConverter">The appearances converter.</param>
        internal MetadataDataContractConverter(IConverter<string, IEnumerable<string>> tagConverter, IConverter<string, IEnumerable<Guid>> appearancesConverter)
        {
            this.tagConverter = tagConverter;
            this.appearancesConverter = appearancesConverter;
        }

        /// <inheritdoc />
        public Character.CharacterMetadata Convert(MetadataDataContract value)
        {
            var metadata = new Character.CharacterMetadata
            {
                IsAlive = value.IsAlive,
                ValidDate = value.ValidDate,
                VoiceActor = value.VoiceActor
            };

            var tags = value.Tags;
            if (!string.IsNullOrEmpty(tags) && !string.IsNullOrWhiteSpace(tags))
            {
                metadata.Tags = this.tagConverter.Convert(tags);
            }

            var appearances = value.Occurrences;
            if (!string.IsNullOrEmpty(appearances) && !string.IsNullOrWhiteSpace(appearances))
            {
                metadata.Occourrences = this.appearancesConverter.Convert(appearances);
            }

            return metadata;
        }
    }
}