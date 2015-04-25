// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a semi-colon separated list into a collection of <see cref="Tag">Tags</see>.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a semi-colon separated list into a collection of <see cref="Tag">Tags</see>.</summary>
    internal class TagConverter : IConverter<string, IEnumerable<string>>
    {
        /// <inheritdoc />
        public IEnumerable<string> Convert(string value)
        {
            char[] separators = { ';' };
            string[] tags = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return tags;
        }
    }
}