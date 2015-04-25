// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OccourcenDataContractCoverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the OccourcenDataContractCoverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RpgTools.Core.Common;

    internal class OccourcenDataContractCoverter : IConverter<string, IEnumerable<Guid>>
    {
        /// <summary>Converts the given object of type <typeparamref name="TInput"/> to an object of type <typeparamref name="TOutput"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public IEnumerable<Guid> Convert(string value)
        {
            char[] separators = { ';' };
            string[] idStrings = value.Split(separators).Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray(); //value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            
            if (idStrings[0] == Guid.Empty.ToString())
            {
                return null;
            }
            
            return idStrings.Select(idString => new Guid(idString)).ToList();
        }
    }
}