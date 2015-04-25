namespace RpgTools.Characters
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Metadata")]
    internal class MetadataDataContract
    {
        /// <summary>Gets or sets the character id. Foreign Key. </summary>
        [Key, ForeignKey("Character")]
        public Guid CharacterId { get; set; }

        /// <summary>Gets or sets the character data contract. Inverse Property.</summary>
        public CharacterDataContract Character { get; set; }

        /// <summary>Gets or sets a value indicating whether the character is alive.</summary>
        public bool IsAlive { get; set; }

        /// <summary>Gets or sets the character tags.</summary>
        public string Tags { get; set; }

        /// <summary>Gets or sets the date for that the character is valid.</summary>
        public string ValidDate { get; set; }

        /// <summary>Gets or sets the voice actor.</summary>
        public string VoiceActor { get; set; }

        /// <summary>Gets or sets the appearances.</summary>
        public string Occurrences { get; set; }
    }
}