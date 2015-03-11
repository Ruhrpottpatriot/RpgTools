// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryRangeConverter.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Converts objects of type <see cref="IResponse{T}" /> to objects of type <see cref="T:IDictionaryRange&lt;TKey, TValue&gt;" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Converts objects of type <see cref="IResponse{T}"/> to objects of type <see cref="T:IDictionaryRange&lt;TKey, TValue&gt;"/>.</summary>
    /// <typeparam name="TDataContract">The type of data contracts in the response content.</typeparam>
    /// <typeparam name="TKey">The type of the key values.</typeparam>
    /// <typeparam name="TValue">The type of the converted values.</typeparam>
    public sealed class DictionaryRangeConverter<TDataContract, TKey, TValue> : IConverter<IResponse<ICollection<TDataContract>>, IDictionaryRange<TKey, TValue>>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<TDataContract, TValue> dataContractConverter;

        /// <summary>Infrastructure. Holds a reference to a key selector expression.</summary>
        private readonly Func<TValue, TKey> keySelector;
        
        /// <summary>Initialises a new instance of the <see cref="DictionaryRangeConverter{TDataContract,TKey,TValue}"/> class.</summary>
        /// <param name="dataContractConverter">The converter for <typeparamref name="TValue"/>.</param>
        /// <param name="keySelector">The key selector expression.</param>
        public DictionaryRangeConverter(IConverter<TDataContract, TValue> dataContractConverter, Func<TValue, TKey> keySelector)
        {
            this.dataContractConverter = dataContractConverter;
            this.keySelector = keySelector;
        }

        /// <inheritdoc />
        public IDictionaryRange<TKey, TValue> Convert(IResponse<ICollection<TDataContract>> value)
        {
            if (value == null)
            {
                return new DictionaryRange<TKey, TValue>(0);
            }

            var dataContract = value.Content;
            if (dataContract == null)
            {
                return new DictionaryRange<TKey, TValue>(0);
            }

            // ToDo: Implement Subtotal routine
            var range = new DictionaryRange<TKey, TValue>(dataContract.Count);

            foreach (var location in dataContract.Select(this.dataContractConverter.Convert))
            {
                range.Add(this.keySelector(location), location);
            }

            foreach (var localizableLocation in range.Values.OfType<ILocalizable>())
            {
                localizableLocation.Culture = value.Culture;
            }

            return range;
        }
    }
}