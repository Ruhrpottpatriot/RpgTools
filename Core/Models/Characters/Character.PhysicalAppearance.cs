// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Character.PhysicalAppearance.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Models
{
    /// <summary>Describes a character.</summary>
    public partial class Character
    {
        /// <summary>Describes the bodily appearance of the character.</summary>
        public class PhysicalAppearance
        {
            // --------------------------------------------------------------------------------------------------------------------
            // Properties
            // -------------------------------------------------------------------------------------------------------------------

            /// <summary>Gets or sets the height in centimetres.</summary>
            public int Height { get; set; }

            /// <summary>Gets or sets the weight in kilograms.</summary>
            public int Weight { get; set; }

            /// <summary>Gets or sets the characters gender.</summary>
            public Genders Gender { get; set; }

            /// <summary>Gets or sets the skin colour.</summary>
            public string SkinColour { get; set; }

            /// <summary>Gets or sets the eye colour.</summary>
            public string EyeColour { get; set; }

            /// <summary>Gets or sets a value indicating whether a character has heterochromia iridum.</summary>
            public bool HeterochromiaIridum { get; set; }

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
}
