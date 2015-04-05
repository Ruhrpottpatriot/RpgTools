// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Character.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Core.Models
{
    using System;

    /// <summary>Represent a Character.</summary>
    public partial class Character : IEquatable<Character>
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Character"/> class.
        /// </summary>
        /// <param name="id">
        /// The id of the SelectedCharacter.
        /// </param>
        public Character(Guid id)
        {
            this.Metadata = new CharacterMetadata(id);
            this.Appearance = new PhysicalAppearance();
            this.Family = new CharacterFamily();
        }

        /// <summary>Gets or sets the image path.</summary>
        public byte[] Portrait { get; set; }

        /// <summary>Gets or sets the characters age.</summary>
        public int Age { get; set; }

        /// <summary>Gets or sets the body properties of a SelectedCharacter.</summary>
        public PhysicalAppearance Appearance { get; set; }

        /// <summary>Gets or sets the character family.</summary>
        public CharacterFamily Family { get; set; }

        /// <summary>Gets or sets the character metadata.</summary>
        public CharacterMetadata Metadata { get; set; }

        /// <summary>Gets or sets the motto.</summary>
        public string Motto { get; set; }

        /// <summary>Gets or sets the nickname.</summary>
        public string Nickname { get; set; }

        /// <summary>Gets or sets the name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the title.</summary>
        public string Title { get; set; }

        /// <summary>The ==.</summary>
        /// <param name="characterA">The character a.</param>
        /// <param name="characterB">The character b.</param>
        /// <returns>True if both characters are the same.</returns>
        public static bool operator ==(Character characterA, Character characterB)
        {
            // ReSharper disable once RedundantNameQualifier
            if (object.ReferenceEquals(characterA, characterB))
            {
                return true;
            }
            else if (((object)characterA == null) || ((object)characterB == null))
            {
                return false;
            }

            return characterA.Metadata.Id == characterB.Metadata.Id;
        }

        /// <summary>The !=.</summary>
        /// <param name="characterA">The character a.</param>
        /// <param name="characterB">The character b.</param>
        /// <returns>True, if both characters are not the same.</returns>
        public static bool operator !=(Character characterA, Character characterB)
        {
            return !(characterA == characterB);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">
        /// An object to compare with this object.
        /// </param>
        public bool Equals(Character other)
        {
            if ((object)other == null)
            {
                return false;
            }

            return this.Metadata.Id == other.Metadata.Id;
        }

        /// <summary>
        /// Compares the current instance with another object for equality.
        /// </summary>
        /// <param name="other">
        /// The other object to compare.
        /// </param>
        /// <returns>
        /// True if both objects are equal.
        /// </returns>
        public override bool Equals(object other)
        {
            var character = other as Character;

            if (character == null)
            {
                return false;
            }

            return character.Metadata.Id == this.Metadata.Id;
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.Metadata.Id.GetHashCode();
        }
    }
}