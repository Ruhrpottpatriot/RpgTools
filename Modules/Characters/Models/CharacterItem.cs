// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterItem.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Represents a characters data as it is stored in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>Represents a characters data as it is stored in the database.</summary>
    [Table("Characters")]
    internal class CharacterItem
    {
        /// <summary>Gets or sets the unique database identifier.</summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the characters nickname.</summary>
        public string Nickname { get; set; }

        /// <summary>Gets or sets the characters title.</summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the description.</summary>
        public string Description { get; set; }

        /// <summary>Gets or sets the biography.</summary>
        public string Biography { get; set; }

        /// <summary>Gets or sets the characters motto.</summary>
        public string Motto { get; set; }

        /// <summary>Gets or sets the age.</summary>
        public int Age { get; set; }

        /// <summary>Gets or sets the portrait id.</summary>
        public Guid PortraitsId { get; set; }

        /// <summary>Gets or sets the portrait.</summary>
        public PortraitItem Portrait { get; set; }

        /// <summary>Gets or sets the metadata id.</summary>
        public Guid MetadataId { get; set; }

        /// <summary>Gets or sets the metadata.</summary>
        public CharacterMetadataItem Metadata { get; set; }

        /// <summary>Gets or sets the appearance id.</summary>
        public Guid AppearanceId { get; set; }

        /// <summary>Gets or sets the appearance.</summary>
        public AppearanceItem Appearance { get; set; }

        /// <summary>Gets or sets the origin id.</summary>
        public Guid OriginId { get; set; }
    }
}
