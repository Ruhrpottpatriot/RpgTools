// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterCompleteRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides methods and properties for a complete character request against the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Characters.DataContracts;

    using RpgTools.Core.Common.Requests;

    /// <summary>Provides methods and properties for a complete character request against the database.</summary>
    internal sealed class CharacterCompleteRequest : CompleteDatabaseRequest<CharacterContext, ICollection<CharacterDataContract>>
    {
        /// <inheritdoc />
        public override Func<CharacterContext, ICollection<CharacterDataContract>> Resource
        {
            get
            {
                return c => c.Characters.ToList();
            }
        }
    }
}