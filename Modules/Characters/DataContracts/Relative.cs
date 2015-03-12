// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Relative.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the Relative type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Characters.DataContracts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>Describes the relation for a relative of a character.</summary>
    [Table("Relatives")]
    internal class Relative
    {
        /// <summary>Gets or sets the relative id.</summary>
        [Key, Column(Order = 0)]
        public Guid RelativeId { get; set; }

        /// <summary>
        /// Gets or sets the character id.
        /// </summary>
        [Key, ForeignKey("Character"), Column(Order = 1)]
        public Guid CharacterId { get; set; }

        /// <summary>Gets or sets the character id.</summary>
        public CharacterDataContract Character { get; set; }
    }
}