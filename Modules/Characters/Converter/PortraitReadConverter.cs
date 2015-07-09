// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PortraitReadConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a <see cref="PortraitItem" /> stored in the database into the corresponding <see cref="Array" /> of type <see cref="byte" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;

    using RpgTools.Core.Common;

    /// <summary>Converts a <see cref="PortraitItem"/> stored in the database into the corresponding <see cref="Array"/> of type <see cref="byte"/>.</summary>
    internal sealed class PortraitReadConverter : IConverter<PortraitItem, byte[]>
    {
        /// <inheritdoc/>
        public byte[] Convert(PortraitItem value)
        {
            return value.Data;
        }
    }
}