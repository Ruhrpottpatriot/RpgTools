// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a <see cref="TagDataContract" /> into the appropriate <see cref="Tag" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Tags
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="TagItem"/> into the appropriate <see cref="Tag"/>.</summary>
    internal class TagWriteConverter : IConverter<Tag, TagItem>
    {
        /// <inheritdoc /> 
        public TagItem Convert(Tag value)
        {
            return new TagItem
            {
                Id = value.Id,
                Tag = value.Value,
                TwoLetterLanguageCode = value.Culture.TwoLetterISOLanguageName,
                Type = value.Type
            };
        }
    }
}