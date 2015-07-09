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
                this.Tags = new List<Tag>();
                this.Occurrences = new List<Guid>();
            }

            // --------------------------------------------------------------------------------------------------------------------
            // Properties
            // --------------------------------------------------------------------------------------------------------------------

            /// <summary>Gets or sets a value indicating whether the character is alive.</summary>
            public bool IsAlive { get; set; }

            /// <summary>Gets or sets the character tags.</summary>
            public IEnumerable<Tag> Tags { get; set; }

            /// <summary>Gets or sets the date for that the character is valid.</summary>
            public string ValidDate { get; set; }

            /// <summary>Gets or sets the voice actor.</summary>
            public string VoiceActor { get; set; }

            /// <summary>Gets or sets the occurrences.</summary>
            public IEnumerable<Guid> Occurrences { get; set; }
        }
    }
}
