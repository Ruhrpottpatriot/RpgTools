namespace RpgTools.Characters
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Appearances")]
    internal class AppearanceDataContract
    {
        /// <summary>Gets or sets the character id. Foreign Key. </summary>
        [Key, ForeignKey("Character")]
        public Guid CharacterId { get; set; }

        /// <summary>Gets or sets the character data contract. Inverse Property.</summary>
        public CharacterDataContract Character { get; set; }

        /// <summary>Gets or sets the height in centimetres.</summary>
        public int Height { get; set; }

        /// <summary>Gets or sets the weight in kilograms.</summary>
        public int Weight { get; set; }

        /// <summary>Gets or sets the characters gender.</summary>
        public int Gender { get; set; }

        /// <summary>Gets or sets a hexadecimal representation of the skin colour.</summary>
        public string SkinColour { get; set; }

        /// <summary>Gets or sets a hexadecimal representation  the eye colour.</summary>
        public string EyeColour { get; set; }

        /// <summary>Gets or sets a value indicating whether a character has heterochromia iridum.</summary>
        public bool HeterochromiaIridum { get; set; }

        /// <summary>Gets or sets a hexadecimal representation the hair colour.</summary>
        public string HairColour { get; set; }

        /// <summary>Gets or sets a hexadecimal representation the lip colour.</summary>
        public string LipColour { get; set; }

        /// <summary>Gets or sets the bust measurement.</summary>
        public short Bust { get; set; }

        /// <summary>Gets or sets the cup size.</summary>
        public string CupSize { get; set; }

        /// <summary>Gets or sets the hip measurement.</summary>
        public short Hip { get; set; }

        /// <summary>Gets or sets the waist measurement.</summary>
        public short Waist { get; set; }
    }
}