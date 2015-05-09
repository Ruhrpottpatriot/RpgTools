// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OccurrenceWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the OccurrenceWriteConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;
    using RpgTools.Core.Common;

    /// <summary>Converts a <see cref="IEnumerable{T}"/> of <see cref="Guid"/> into a semi-colon separated string.</summary>
    internal sealed class OccurrenceWriteConverter : IConverter<IEnumerable<Guid>, string>
    {
        /// <summary>Converts the given object of type <typeparamref name="TInput"/> to an object of type <typeparamref name="TOutput"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public string Convert(IEnumerable<Guid> value)
        {
            return string.Join("; ", value);
        }
    }
}