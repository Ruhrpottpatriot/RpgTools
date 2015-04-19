namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    internal class MetadataDataContractConverter : IConverter<MetadataDataContract, Character.CharacterMetadata>
    {
        private readonly IConverter<string, IEnumerable<string>> tagConverter;

        private readonly IConverter<string, IEnumerable<Guid>> appearancesConverter;
        

        public MetadataDataContractConverter()
            :this(new TagConverter(), new AppearancesCoverter())
        {
        }

        public MetadataDataContractConverter(IConverter<string, IEnumerable<string>> tagConverter, IConverter<string, IEnumerable<Guid>> appearancesConverter)
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

            var appearances = value.Appearances;
            if (!string.IsNullOrEmpty(appearances) && !string.IsNullOrWhiteSpace(appearances))
            {
                metadata.Appearances = this.appearancesConverter.Convert(appearances);
            }

            return metadata;
        }
    }
}