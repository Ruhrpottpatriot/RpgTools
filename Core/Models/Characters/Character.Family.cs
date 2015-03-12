// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Character.Family.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Core.Models.Characters
{
    using System;
    using System.Collections.ObjectModel;

    /// <summary>
    /// The SelectedCharacter.
    /// </summary>
    public partial class Character
    {
        /// <summary>
        /// The family.
        /// </summary>
        public class CharacterFamily
        {
            // --------------------------------------------------------------------------------------------------------------------
            // Properties
            // -------------------------------------------------------------------------------------------------------------------

            /// <summary>
            /// Gets or sets the spouse.
            /// </summary>
            public Guid Spouse { get; set; }

            /// <summary>
            /// Gets or sets the siblings.
            /// </summary>
            public ObservableCollection<Guid> Siblings { get; set; }

            /// <summary>
            /// Gets or sets the mother.
            /// </summary>
            public Guid Mother { get; set; }

            /// <summary>
            /// Gets or sets the father.
            /// </summary>
            public Guid Father { get; set; }

            /// <summary>
            /// Gets or sets the children.
            /// </summary>
            public ObservableCollection<Guid> Children { get; set; }
        }
    }
}
