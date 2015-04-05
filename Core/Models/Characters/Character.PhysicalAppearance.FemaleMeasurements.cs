// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Character.PhysicalAppearance.FemaleMeasurements.cs" company="Robert Logiewa">
//   (C) All rights reseved
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
        /// <summary>The bodily appearance of the character.</summary>
        public partial class PhysicalAppearance
        {
            /// <summary>
            /// The measurements of a female character.
            /// </summary>
            public class FemaleMeasurements
            {
                // --------------------------------------------------------------------------------------------------------------------
                // Properties
                // -------------------------------------------------------------------------------------------------------------------

                /// <summary>
                /// Gets or sets the bust measurement.
                /// </summary>
                public short Bust { get; set; }

                /// <summary>
                /// Gets or sets the cup size.
                /// </summary>
                public string CupSize { get; set; }

                /// <summary>
                /// Gets or sets the hip measurement.
                /// </summary>
                public short Hip { get; set; }

                /// <summary>
                /// Gets or sets the waist measurement.
                /// </summary>
                public short Waist { get; set; }
            }
        }
    }
}