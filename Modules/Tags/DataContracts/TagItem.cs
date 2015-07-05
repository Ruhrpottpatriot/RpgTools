// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagDataContract.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the TagDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Tags
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>Describes the tag type as it is stored in the database.</summary>
    [Table("Tags")]
    internal sealed class TagItem
    {
        /// <summary>Gets or sets the tags id.</summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>Gets or sets the tag value itself.</summary>
        public string Tag { get; set; }

        /// <summary>Gets or sets the type the tag belongs to.</summary>
        public string Type { get; set; }

        /// <summary>Gets or sets the two letter language code.</summary>
        public string TwoLetterLanguageCode { get; set; }
    }
}
