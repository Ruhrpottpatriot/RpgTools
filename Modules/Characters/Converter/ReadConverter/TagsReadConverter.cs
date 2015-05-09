// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagsReadConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the TagsReadConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;
    using RpgTools.Core.Common;

    /// <summary>Converts a semi-colon separated string of tags into the corresponding list of tags.</summary>
    internal sealed class TagsReadConverter : IConverter<string, IEnumerable<string>>
    {
        /// <inheritdoc />
        public IEnumerable<string> Convert(string value)
        {
            char[] separators = { ';', ' ' };

            return value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}