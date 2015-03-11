// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConverter.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides the interface for classes that convert one type to another type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    /// <summary>Provides the interface for classes that convert one type to another type.</summary>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    /// <typeparam name="TOutput">The type of the output.</typeparam>
    public interface IConverter<in TInput, out TOutput>
    {
        /// <summary>Converts the given object of type <typeparamref name="TInput"/> to an object of type <typeparamref name="TOutput"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        TOutput Convert(TInput value);
    }
}