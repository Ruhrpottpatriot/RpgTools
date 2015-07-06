// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagReadConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a <see cref="TagItem"/> into the appropriate <see cref="Tag"/>.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Tags
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="TagItem"/> into the appropriate <see cref="Tag"/>.</summary>
    internal sealed class TagReadConverter : IConverter<TagItem, Tag>
    {
        /// <inheritdoc />
        public Tag Convert(TagItem value)
        {
            return new Tag { Id = value.Id, Value = value.Tag, Type = value.Type };
        }
    }
}