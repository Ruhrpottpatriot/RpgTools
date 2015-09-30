// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagListToStringConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts a collection of Tags into a semi-colon separeted list and vice versa.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Converter
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>Converts a collection of Tags into a semi-colon separated list and vice versa.</summary>
    public class TagListToStringConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value produced by the binding source.</param><param name="targetType">The type of the binding target property.</param><param name="parameter">The converter parameter to use.</param><param name="culture">The culture to use in the converter.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IEnumerable<string> tags = value as IEnumerable<string>;

            return tags != null ? string.Join("; ", tags) : string.Empty;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value that is produced by the binding target.</param><param name="targetType">The type to convert to.</param><param name="parameter">The converter parameter to use.</param><param name="culture">The culture to use in the converter.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            char[] separators = new[] { ';', ',', ' ' };

            string tagString = value as string;

            if (tagString != null)
            {
                return tagString.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            }

            return new List<string>();
        }
    }
}
