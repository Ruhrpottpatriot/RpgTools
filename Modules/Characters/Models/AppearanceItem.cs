// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppearanceItem.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Represents a characters physical appearance as it is stored in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using RpgTools.Core.Models;

    /// <summary>Represents a characters physical appearance as it is stored in the database.</summary>
    [Table("Appearances", Schema = "Characters")]
    internal sealed class AppearanceItem
    {
        /// <summary>Gets or sets the unique database identifier.</summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>Gets or sets the gender.</summary>
        public Genders Gender { get; set; }

        /// <summary>Gets or sets the height.</summary>
        public int Height { get; set; }

        /// <summary>Gets or sets the weight.</summary>
        public int Weight { get; set; }

        /// <summary>Gets or sets the skin colour.</summary>
        public string SkinColour { get; set; }

        /// <summary>Gets or sets the eye colour.</summary>
        public string EyeColour { get; set; }

        /// <summary>Gets or sets the special features as a semi-colon separated list.</summary>
        public string SpecialFeatures { get; set; }

        /// <summary>Gets or sets the hair colour.</summary>
        public string HairColour { get; set; }

        /// <summary>Gets or sets the lip colour.</summary>
        public string LipColour { get; set; }

        /// <summary>Gets or sets the bust measurement.</summary>
        public short Bust { get; set; }

        /// <summary>Gets or sets the cup size.</summary>
        public char CupSize { get; set; }

        /// <summary>Gets or sets the hip measurement.</summary>
        public short Hip { get; set; }

        /// <summary>Gets or sets the waist measurement.</summary>
        public short Waist { get; set; }
    }
}