// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PhysicalApperance.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Characters.DataContracts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>Represents the physical appearance of a character.</summary>
    [Table("PhysicalApperance")]
    internal class PhysicalApperance
    {
        /// <summary>Gets or sets the character id.</summary>
        [Key, ForeignKey("Character")]
        public Guid CharacterId { get; set; }

        /// <summary>Gets or sets the character.</summary>
        public CharacterDataContract Character { get; set; }

        /// <summary>Gets or sets the height.</summary>
        public int Height { get; set; }

        /// <summary>Gets or sets the bust circumference.</summary>
        public short Bust { get; set; }

        /// <summary>Gets or sets the cup size.</summary>
        public string CupSize { get; set; }

        /// <summary>Gets or sets the hip circumference.</summary>
        public short Hip { get; set; }

        /// <summary>Gets or sets the waist circumference.</summary>
        public short Waist { get; set; }

        /// <summary>Gets or sets the gender.</summary>
        public string Gender { get; set; }

        /// <summary>Gets or sets the skin colour.</summary>
        public string SkinColour { get; set; }

        /// <summary>Gets or sets the eye colour.</summary>
        public string EyeColour { get; set; }

        /// <summary>Gets or sets the hair colour.</summary>
        public string HairColour { get; set; }

        /// <summary>Gets or sets a value indicating whether a character has heterochromia iridum.</summary>
        public bool HeterochromiaIridum { get; set; }

        /// <summary>Gets or sets the lip colour.</summary>
        public string LipColour { get; set; }
    }
}