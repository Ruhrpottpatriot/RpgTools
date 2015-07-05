namespace RpgTools.Characters
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>Represents the metadata of a specifc character.</summary>
    [Table("Metadata")]
    internal class CharacterMetadataItem
    {
        /// <summary>Gets or sets the unique database identifier.</summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>Gets or sets the list of tags as a semi-colon seperated string.</summary>
        public string Tags { get; set; }

        /// <summary>Gets or sets the voice actor.</summary>
        public string VoiceActor { get; set; }

        /// <summary>Gets or sets the list of occourrences as a semi-colon seperated string.</summary>
        public string Occurrences { get; set; }
    }
}
