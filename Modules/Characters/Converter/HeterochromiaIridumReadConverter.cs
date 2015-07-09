// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HeterochromiaIridumReadConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Extracts whether a character has Heterochromia Iridum from a <see cref="string" /> representation of special features.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.Linq;

    using RpgTools.Core.Common;

    /// <summary>Extracts whether a character has Heterochromia Iridum from a <see cref="string"/> representation of special features.</summary>
    internal sealed class HeterochromiaIridumReadConverter : IConverter<string, bool>
    {
        /// <inheritdoc/>
        public bool Convert(string value)
        {
            char[] separators = { ';' };

            string[] values = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return values.Any(i => i == "heterochromia_iridum");
        }
    }
}