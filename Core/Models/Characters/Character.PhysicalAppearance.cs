// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Character.PhysicalAppearance.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Models
{
    /// <summary>Describes a character.</summary>
    public partial class Character
    {
        /// <summary>Describes the bodily appearance of the character.</summary>
        public partial class PhysicalAppearance
        {
            // --------------------------------------------------------------------------------------------------------------------
            // Constructors & Destructors
            // -------------------------------------------------------------------------------------------------------------------

            /// <summary>
            /// Initialises a new instance of the <see cref="PhysicalAppearance"/> class. Initializes a new instance of the <see cref="PhysicalAppearance"/> class.
            /// </summary>
            public PhysicalAppearance()
            {
                this.Measurements = new FemaleMeasurements();
                this.Face = new CharacterFace();
            }

            // --------------------------------------------------------------------------------------------------------------------
            // Enumerations
            // -------------------------------------------------------------------------------------------------------------------

            /// <summary>
            /// The gender of a SelectedCharacter.
            /// </summary>
            public enum Genders
            {
                /// <summary>
                /// The male gender.
                /// </summary>
                Male, 

                /// <summary>
                /// The female gender.
                /// </summary>
                Female, 

                /// <summary>
                /// The neutral gender.
                /// </summary>
                Neutral
            }

            // --------------------------------------------------------------------------------------------------------------------
            // Properties
            // -------------------------------------------------------------------------------------------------------------------

            /// <summary>
            /// Gets or sets the height.
            /// </summary>
            public int Height { get; set; }

            /// <summary>Gets or sets the characters face.</summary>
            public CharacterFace Face { get; set; }

            /// <summary>
            /// Gets or sets the measurements.
            /// </summary>
            public FemaleMeasurements Measurements { get; set; }

            /// <summary>
            /// Gets or sets the character gender.
            /// </summary>
            public Genders Gender { get; set; }

            /// <summary>
            /// Gets or sets the skin colour.
            /// </summary>
            public string SkinColour { get; set; }
        }
    }
}
