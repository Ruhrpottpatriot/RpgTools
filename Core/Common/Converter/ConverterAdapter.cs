// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterAdapter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Represents an adapter for the <see cref="IConverter{TInput,TOutput}" /> interface that does not do any conversions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    /// <summary>Represents an adapter for the <see cref="IConverter{TInput,TOutput}"/> interface that does not do any conversions.</summary>
    /// <typeparam name="T">The type of the value that needs to be adapted.</typeparam>
    public class ConverterAdapter<T> : IConverter<T, T>
    {
        /// <inheritdoc />
        public T Convert(T value)
        {
            return value;
        }
    }
}