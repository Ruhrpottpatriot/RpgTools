// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OccurrencesReadConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Convertrs a semi-colon separated string of occourcen id into the corresponding list of occourence GUIDs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RpgTools.Core.Common;

    /// <summary>Converts a semi-colon separated string of occurrence ids into the corresponding list of occurrence GUIDs.</summary>
    internal sealed class OccurrencesReadConverter : IConverter<string, IEnumerable<Guid>>
    {
        /// <inheritdoc />
        public IEnumerable<Guid> Convert(string value)
        {
            char[] separators = { ';', ' ' };

            string[] ids = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return ids.Select(id => new Guid(id));
        }
    }
}