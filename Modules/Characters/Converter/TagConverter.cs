namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RpgTools.Core.Common;

    internal class TagConverter : IConverter<string, IEnumerable<string>>
    {
        /// <summary>Converts the given object of type <typeparamref name="TInput"/> to an object of type <typeparamref name="TOutput"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public IEnumerable<string> Convert(string value)
        {
            char[] separators = { ';' };
            string[] tags = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return tags;
        }
    }
}