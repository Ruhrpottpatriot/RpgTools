// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetadataDatabaseItem.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the MetadataDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>Represents a metadata object stored in the database.</summary>
    [Table("Character_Metadata")]
    internal class MetadataDatabaseItem
    {
        /// <summary>Gets or sets the id. </summary>
        [Key]
        public Guid Id { get; set; }
       
        /// <summary>Gets or sets the character tags.</summary>
        public string Tags { get; set; }
        
        /// <summary>Gets or sets the voice actor.</summary>
        public string VoiceActor { get; set; }

        /// <summary>Gets or sets the appearances.</summary>
        public string Occurrences { get; set; }
    }
}