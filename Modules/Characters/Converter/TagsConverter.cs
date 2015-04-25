// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagsConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a list of tag strings into a semi-colon separated list for storage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System.Collections.Generic;
    using RpgTools.Core.Common;

    /// <summary>Converts a list of tag strings into a semi-colon separated list for storage.</summary>
    internal sealed class TagsConverter : IConverter<IEnumerable<string>, string>
    {
        /// <inheritdoc /> 
        public string Convert(IEnumerable<string> value)
        {
            return string.Join(";", value);
        }
    }
}