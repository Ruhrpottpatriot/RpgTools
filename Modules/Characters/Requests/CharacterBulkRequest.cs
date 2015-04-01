// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterBulkRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides methods and properties for a character bulk request against the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Characters.DataContracts;

    using RpgTools.Core.Common;

    /// <summary>Provides methods and properties for a character bulk request against the database.</summary>
    internal sealed class CharacterBulkRequest : IRequest
    {
        /// <inheritdoc />
        public Func<CharacterContext, ICollection<CharacterDataContract>> Resource
        {
            get
            {
                return c => c.Characters.Where(ch => this.Identifiers.Any(i => i == ch.Id)).ToList();
            }
        }

        public ICollection<Guid> Identifiers { get; set; }
    }
}