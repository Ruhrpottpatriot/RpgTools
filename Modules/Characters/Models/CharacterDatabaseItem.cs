// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterDatabaseItem.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the CharacterDatabaseItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>Represents a character stored in a relational database.</summary>
    internal class CharacterDatabaseItem
    {
        /// <summary>Gets or sets the id.</summary>
        [Key, Column(Order = 0)]
        public Guid Id { get; set; }

        /// <summary>Gets or sets the culture.</summary>
        [Key, Column(Order = 1)]
        public string Culture { get; set; }

        /// <summary>Gets or sets the full name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the nickname.</summary>
        public string Nickname { get; set; }

        /// <summary>Gets or sets the title.</summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the description.</summary>
        public string Description { get; set; }

        /// <summary>Gets or sets the biography.</summary>
        public string Biography { get; set; }

        /// <summary>Gets or sets the motto.</summary>
        public string Motto { get; set; }

        /// <summary>Gets or sets the characters age.</summary>
        public int Age { get; set; }

        /// <summary>Gets or sets the portrait.</summary>
        public byte[] Portrait { get; set; }

        /// <summary>Gets or sets the origin id.</summary>
        public Guid OriginId { get; set; }

        /// <summary>Gets or sets the appearance id.</summary>
        public Guid AppearanceId { get; set; }

        /// <summary>Gets or sets the appearance database item.</summary>
        [ForeignKey("AppearanceId")]
        public AppearanceDatabaseItem AppearanceDatabaseItem { get; set; }

        /// <summary>Gets or sets the metadata id.</summary>
        public Guid MetadataId { get; set; }

        /// <summary>Gets or sets the metadata database item.</summary>
        [ForeignKey("MetadataId")]
        public MetadataDatabaseItem MetadataDatabaseItem { get; set; }
    }
}
