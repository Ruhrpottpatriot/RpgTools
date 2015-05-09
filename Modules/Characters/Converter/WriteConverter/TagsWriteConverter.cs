// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagsWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the TagsWriteConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System.Collections.Generic;
    using RpgTools.Core.Common;

    /// <summary>Converts a <see cref="IEnumerable{T}"/> of <see cref="string"/> into a semi-colon separated string.</summary>
    internal sealed class TagsWriteConverter : IConverter<IEnumerable<string>, string>
    {
        /// <inheritdoc />
        public string Convert(IEnumerable<string> value)
        {
            return string.Join("; ", value);
        }
    }
}