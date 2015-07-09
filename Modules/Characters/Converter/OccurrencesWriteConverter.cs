// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OccurrencesWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a <see cref="IEnumerable{T}" /> of type <see cref="Guid" /> into a semi-colon separated string.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;

    using RpgTools.Core.Common;

    /// <summary>Converts a <see cref="IEnumerable{T}"/> of type <see cref="Guid"/> into a semi-colon separated string.</summary>
    internal sealed class OccurrencesWriteConverter : IConverter<IEnumerable<Guid>, string>
    {
        /// <inheritdoc/>
        public string Convert(IEnumerable<Guid> value)
        {
            return string.Join("; ", value);
        }
    }
}