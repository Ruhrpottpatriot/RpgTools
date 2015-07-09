// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OccourrencesReadConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a semi-colon separated string into an <see cref="IEnumerable{T}" /> of type <see cref="Guid" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using RpgTools.Core.Common;

    /// <summary>Converts a semi-colon separated string into an <see cref="IEnumerable{T}"/> of type <see cref="Guid"/>.</summary>
    internal class OccourrencesReadConverter : IConverter<string, IEnumerable<Guid>>
    {
        /// <inheritdoc/>
        public IEnumerable<Guid> Convert(string value)
        {
            char[] separators = { ';' };
            string[] ids = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return ids.Select(id => new Guid(id));
        }
    }
}