// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Character.Metadata.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Core.Models.Characters
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
            
            /// <summary>
            /// Initialises a new instance of the <see cref="CharacterMetadata"/> class.
            /// </summary>
            /// <param name="characterId">
            /// The Id for this character.
            /// </param>
            public CharacterMetadata(Guid characterId)
            {
                this.Id = characterId;
                this.Tags = new List<string>();
            }

            // --------------------------------------------------------------------------------------------------------------------
            // Properties
            // --------------------------------------------------------------------------------------------------------------------

            /// <summary>Gets or sets the id.</summary>
            public Guid Id { get; set; }

            /// <summary>Gets or sets a value indicating whether the character is alive.</summary>
            public bool IsAlive { get; set; }

            /// <summary>Gets or sets the character tags.</summary>
            public List<string> Tags { get; set; }

            /// <summary>Gets or sets the date for that the character is valid.</summary>
            public string ValidDate { get; set; }

            /// <summary>Gets or sets the voice actor.</summary>
            public string VoiceActor { get; set; }
        }
    }
}
