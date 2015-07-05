namespace RpgTools.Characters
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>Represents a character.</summary>
    internal class CharacterItem
    {
        /// <summary>Gets or sets the unique database identifier.</summary>
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Biography { get; set; }

        public string Motto { get; set; }

        public int Age { get; set; }

        public Guid PortraitId { get; set; }
        
        [ForeignKey("PortraitId")]
        public PortraitItem Portrait { get; set; }

        public Guid MetadataId { get; set; }

        [ForeignKey("MetadataId")]
        public CharacterMetadataItem Metadata { get; set; }

        public Guid AppearanceId { get; set; }

        [ForeignKey("AppearanceId")]
        public AppearanceItem Appearance { get; set; }

        public Guid OriginId { get; set; }
    }
}
