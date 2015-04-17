// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Character.Metadata.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Core.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>Represent a Character.</summary>
    public partial class Character
    {
        /// <summary>The metadata for the character.</summary>
        public class CharacterMetadata
        {
            // --------------------------------------------------------------------------------------------------------------------
            // Constructor
            // --------------------------------------------------------------------------------------------------------------------
            
            /// <summary>Initialises a new instance of the <see cref="CharacterMetadata"/> class.</summary>
            public CharacterMetadata()
            {
                this.Tags = new List<string>();
                this.Appearances = new List<Guid>();
            }

            // --------------------------------------------------------------------------------------------------------------------
            // Properties
            // --------------------------------------------------------------------------------------------------------------------

            /// <summary>Gets or sets a value indicating whether the character is alive.</summary>
            public bool IsAlive { get; set; }

            /// <summary>Gets or sets the character tags.</summary>
            public IList<string> Tags { get; set; }

            /// <summary>Gets or sets the date for that the character is valid.</summary>
            public string ValidDate { get; set; }

            /// <summary>Gets or sets the voice actor.</summary>
            public string VoiceActor { get; set; }

            /// <summary>Gets or sets the appearances.</summary>
            public IList<Guid> Appearances { get; set; }
        }
    }
}
