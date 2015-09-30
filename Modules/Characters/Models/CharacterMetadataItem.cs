// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterMetadataItem.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Represents the metadata of a specifc character.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>Represents a characters metadata as it is stored inside the database.</summary>
    [Table("Metadata", Schema = "Characters")]
    internal class CharacterMetadataItem
    {
        /// <summary>Gets or sets the unique database identifier.</summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>Gets or sets the list of tags as a semi-colon separated string.</summary>
        public string Tags { get; set; }

        /// <summary>Gets or sets the voice actor.</summary>
        public string VoiceActor { get; set; }

        /// <summary>Gets or sets the list of occurrences as a semi-colon separated string.</summary>
        public string Occurrences { get; set; }
    }
}
