// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterDataContract.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Represents a character object stored in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>Represents a character object stored in the database.</summary>
    [Table("Characters")]
    internal class CharacterDataContract
    {
        /// <summary>Gets or sets the id.</summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the nickname.</summary>
        public string Nickname { get; set; }

        /// <summary>Gets or sets the title.</summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the short description.</summary>
        public string ShortDescription { get; set; }

        /// <summary>Gets or sets the motto.</summary>
        public string Motto { get; set; }

        /// <summary>Gets or sets the characters age.</summary>
        public int Age { get; set; }

        /// <summary>Gets or sets the image path.</summary>
        public byte[] Portrait { get; set; }

        /// <summary>Gets or sets the id of the characters origin location.</summary>
        public Guid OriginId { get; set; }

        /// <summary>Gets or sets the family id.</summary>
        public Guid FamilyId { get; set; }
        
        /// <summary>Gets or sets the appearance dependency property.</summary>
        public virtual AppearanceDataContract Appearance { get; set; }

        /// <summary>Gets or sets the metadata dependency property.</summary>
        public virtual MetadataDataContract Metadata { get; set; }
    }
}