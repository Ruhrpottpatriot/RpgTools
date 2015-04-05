// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Character.PhysicalAppearance.Face.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Models
{
    /// <summary>
    /// The SelectedCharacter.
    /// </summary>
    public partial class Character
    {
        /// <summary>Describes the physical appearance.</summary>
        public partial class PhysicalAppearance
        {
            /// <summary>Describes the characters face.</summary>
            public class CharacterFace
            {
                // -------------------------------------------------------------------------------------------------------------------
                // Properties
                // -------------------------------------------------------------------------------------------------------------------

                /// <summary>
                /// Gets or sets the eye colour.
                /// </summary>
                public string EyeColour { get; set; }

                /// <summary>
                /// Gets or sets the hair colour.
                /// </summary>
                public string HairColour { get; set; }

                /// <summary>
                /// Gets or sets a value indicating whether a character has heterochromia iridum.
                /// </summary>
                public bool HeterochromiaIridum { get; set; }

                /// <summary>
                /// Gets or sets the lip colour.
                /// </summary>
                public string LipColour { get; set; }
            }
        }
    }
}