// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagsWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts an <see cref="IEnumerable{T}" /> of type <see cref="Tag" /> into a semi-colon separated string for storage in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System.Collections.Generic;
    using System.Text;

    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts an <see cref="IEnumerable{T}"/> of type <see cref="Tag"/> into a semi-colon separated string for storage in the database.</summary>
    internal sealed class TagsWriteConverter : IConverter<IEnumerable<Tag>, string>
    {
        /// <inheritdoc/>
        public string Convert(IEnumerable<Tag> value)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Tag tag in value)
            {
                stringBuilder.Append(tag.Id + ";");
            }

            return stringBuilder.ToString();
        }
    }
}