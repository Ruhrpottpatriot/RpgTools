// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterDiscoveryRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides methods and properties to querys a database for character ids.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Characters.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using RpgTools.Core.Common.Requests;

    /// <summary>Provides methods and properties to queries a database for character ids.</summary>
    internal sealed class CharacterDiscoveryRequest : DatabaseDiscoveryRequest<CharacterContext, ICollection<Guid>>
    {
        /// <inheritdoc />
        public override Func<CharacterContext, ICollection<Guid>> Resource
        {
            get
            {
                return c => c.Characters.Select(ch => ch.Id).ToList();
            }
        }
    }
}