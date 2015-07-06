// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagDataContractConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the TagDataContractConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Tags
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Describes the tag object stored in the database.</summary>
    internal sealed class TagReadConverter : IConverter<TagItem, Tag>
    {
        /// <inheritdoc />
        public Tag Convert(TagItem value)
        {
            return new Tag { Id = value.Id, Value = value.Tag, Type = value.Type };
        }
    }
}