// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumExtensionMethods.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Prvides extension methods for enumerations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Extensions
{
    using System;
    using System.ComponentModel;
    using System.Reflection;

    /// <summary>Provides extension methods for enumerations.
    /// </summary>
    public class EnumExtensionMethods
    {
        /// <summary>Gets the description of an enum.</summary>
        /// <param name="value">The enum to get the value from.</param>
        /// <returns>The description <see cref="string"/>.</returns>
        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
