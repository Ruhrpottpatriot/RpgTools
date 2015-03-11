// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDictionaryRange.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides the interface for <see cref="IDictionary{TKey,TValue}" /> types that represent a range.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System.Collections.Generic;

    /// <summary>Provides the interface for <see cref="IDictionary{TKey,TValue}"/> types that represent a range.</summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    public interface IDictionaryRange<TKey, TValue> : IDictionary<TKey, TValue>, ISubsetContext
    {
    }
}