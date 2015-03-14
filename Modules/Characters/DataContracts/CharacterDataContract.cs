// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterDataContract.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the CharacterDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Characters.DataContracts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using RpgTools.Core.Common;

    /// <summary>Represents a character stored in the database.</summary>
    [Table("Characters")]
    internal class CharacterDataContract
    {
        /// <summary>Gets or sets the id.</summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>Gets or sets the age.</summary>
        public int Age { get; set; }

        /// <summary>Gets or sets the motto.</summary>
        public string Motto { get; set; }

        /// <summary>Gets or sets the nickname.</summary>
        public string Nickname { get; set; }

        /// <summary>Gets or sets the name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the title.</summary>
        public string Title { get; set; }

        /// <summary>Gets or sets a value indicating whether is alive.</summary>
        public bool? IsAlive { get; set; }

        /// <summary>Gets or sets the tags.</summary>
        public List<string> Tags { get; set; }

        /// <summary>Gets or sets the voice actor.</summary>
        public string VoiceActor { get; set; }

        /// <summary>Gets or sets the portrait byte array.</summary>
        public byte[] Portrait { get; set; }

        /// <summary>Gets or sets the appearance.</summary>
        public PhysicalApperance Appearance { get; set; }
    }
}