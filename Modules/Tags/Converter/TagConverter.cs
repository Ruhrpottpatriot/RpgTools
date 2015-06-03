// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a <see cref="TagDataContract" /> into the appropriate <see cref="Tag" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Tags
{
    using System.Diagnostics.Contracts;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Converts a <see cref="TagDataContract"/> into the appropriate <see cref="Tag"/>.</summary>
    internal class TagConverter : IConverter<Tag, TagDataContract>
    {
        /// <inheritdoc /> 
        public TagDataContract Convert(Tag value)
        {
            return new TagDataContract
            {
                Id = value.Id,
                Tag = value.Value,
                TwoLetterLanguageCode = value.Culture.TwoLetterISOLanguageName,
                Type = value.Type
            };
        }
    }
}