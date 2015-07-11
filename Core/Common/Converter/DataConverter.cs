// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Converts objects of type <see cref="IDataContainer{T}" /> to objects of type <see cref="TValue" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    /// <summary>Converts objects of type <see cref="IDataContainer{T}"/> to objects of type <see cref="TValue"/>.</summary>
    /// <typeparam name="TDataContract">The type of data contracts in the response content.</typeparam>
    /// <typeparam name="TValue">The type of the converted value.</typeparam>
    public sealed class DataConverter<TDataContract, TValue> : IConverter<IDataContainer<TDataContract>, TValue>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<TDataContract, TValue> dataContractConverter;

        /// <summary>
        /// Initialises a new instance of the <see cref="DataConverter{TDataContract,TValue}"/> class.
        /// </summary>
        /// <param name="dataContractConverter">
        /// The converter for <typeparamref name="TDataContract"/>.
        /// </param>
        public DataConverter(IConverter<TDataContract, TValue> dataContractConverter)
        {
            this.dataContractConverter = dataContractConverter;
        }

        /// <inheritdoc />
        TValue IConverter<IDataContainer<TDataContract>, TValue>.Convert(IDataContainer<TDataContract> value)
        {
            TDataContract dataContract = value.Content;

            // Check if the dataContract is empty and return the default value fot TValue
            // ReSharper disable once RedundantNameQualifier
            if (object.Equals(dataContract, default(TDataContract)))
            {
                return default(TValue);
            }

            // Convert the item.
            TValue item = this.dataContractConverter.Convert(dataContract);

            // Set the localizsation of the item.
            ILocalizable localizableItem = item as ILocalizable;
            if (localizableItem != null)
            {
                localizableItem.Culture = value.Culture;
            }

            // Set the time of the item.
            ITimeSensitive timesensitiveItem = item as ITimeSensitive;
            if (timesensitiveItem != null)
            {
                timesensitiveItem.Timestamp = value.Date;
            }

            // Return the item itself.
            return item;
        }
    }
}