// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OccurrencesConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a collection of occurrences into a semi-colon separated string for storage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;
    using RpgTools.Core.Common;

    /// <summary>Converts a collection of occurrences into a semi-colon separated string for storage.</summary>
    internal sealed class OccurrencesConverter : IConverter<IEnumerable<Guid>, string>
    {
        /// <inheritdoc /> 
        public string Convert(IEnumerable<Guid> value)
        {
            return string.Join(";", value);
        }
    }
}