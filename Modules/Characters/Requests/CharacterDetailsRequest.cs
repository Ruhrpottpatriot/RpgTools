// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterDetailsRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the CharacterDetailsRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Characters
{
    using System;
    using System.Linq;

    using Characters.DataContracts;

    using RpgTools.Core.Common.Requests;

    /// <summary>Provides methods and properties for a character request against a database.</summary>
    internal sealed class CharacterDetailsRequest : DatabaseDetailsRequest<CharacterContext, CharacterDataContract, Guid>
    {
        /// <inheritdoc />
        public override Func<CharacterContext, CharacterDataContract> Resource
        {
            get
            {
                return c => c.Characters.SingleOrDefault(i => i.Id == this.Identifier);
            }
        }
    }
}