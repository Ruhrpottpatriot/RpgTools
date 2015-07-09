// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HeterochromiaIridumWriteConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts whether a character has Heterochromia Iridum into a string representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using RpgTools.Core.Common;

    /// <summary>Converts whether a character has Heterochromia Iridum into a string representation.</summary>
    internal sealed class HeterochromiaIridumWriteConverter : IConverter<bool, string>
    {
        /// <inheritdoc/>
        public string Convert(bool value)
        {
            return value ? "heterochromia_iridum" : string.Empty;
        }
    }
}