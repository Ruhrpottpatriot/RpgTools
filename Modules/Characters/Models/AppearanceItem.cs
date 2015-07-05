namespace RpgTools.Characters
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using RpgTools.Core.Models;

    internal sealed class AppearanceItem
    {
        [Key]
        public Guid Id { get; set; }
        
        public Genders Gender { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public string SkinColour { get; set; }

        public string EyeColour { get; set; }

        public string SpecialFeatures { get; set; }

        public string HairColour { get; set; }

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