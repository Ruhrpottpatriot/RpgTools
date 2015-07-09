// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagsReadConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a semi-colon separated string into a <see cref="IEnumerable{T}" /> of type <see cref="Tag" />, with initially only the id present.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a semi-colon separated string into a <see cref="IEnumerable{T}"/> of type <see cref="Tag"/>, with initially only the id present.</summary>
    internal sealed class TagsReadConverter : IConverter<string, IEnumerable<Tag>>
    {
        /// <inheritdoc/>
        public IEnumerable<Tag> Convert(string value)
        {
            char[] separators = { ';' };
            string[] ids = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return ids.Select(id => new Tag { Id = new Guid(id) });
        }
    }
}