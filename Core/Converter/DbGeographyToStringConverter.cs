// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DbGeographyToStringConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Converter
{
    using System;
    using System.Data.Entity.Spatial;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Windows.Data;

    /// <summary>Converts a <see cref="DbGeography"/> object into its string representation and back.</summary>
    public class DbGeographyToStringConverter : IValueConverter
    {
        /// <summary>Converts a value. </summary>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType"> The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DbGeography)
            {
                var returnValue = ((DbGeography)value).AsText();

                var regexVal = Regex.Match(returnValue, @"(?<=\().+?(?=\))").Value.Replace(" ", ", ");

                return regexVal;
            }

            return null;
        }

        /// <summary>Converts a value.</summary>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // ToDo: Implement logic for multi poiont structures.
            if (value is string)
            {
                char[] delimiter = { ',', ';', ' ' };

                var coordinateNumbers = ((string)value).Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

                if (coordinateNumbers.Length != 2)
                {
                    return null;
                }

                var coordinateText = string.Format("POINT({0} {1})", coordinateNumbers[0], coordinateNumbers[1]);

                return DbGeography.FromText(coordinateText);
            }

            return null;
        }
    }
}
