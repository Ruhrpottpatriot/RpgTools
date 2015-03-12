// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponseConverter.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations.Converter
{
    using RpgTools.Core.Common;

    /// <summary>
    /// Converts objects of type <see cref="IResponse{T}"/> to objects of type <see cref="TValue"/>.
    /// </summary>
    /// <typeparam name="TDataContract">
    /// The type of data contracts in the response content.
    /// </typeparam>
    /// <typeparam name="TValue">
    /// The type of the converted value.
    /// </typeparam>
    public sealed class ResponseConverter<TDataContract, TValue> : IConverter<IResponse<TDataContract>, TValue>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<TDataContract, TValue> dataContractConverter;

        /// <summary>
        /// Initialises a new instance of the <see cref="ResponseConverter{TDataContract,TValue}"/> class.
        /// </summary>
        /// <param name="dataContractConverter">
        /// The converter for <typeparamref name="TDataContract"/>.
        /// </param>
        public ResponseConverter(IConverter<TDataContract, TValue> dataContractConverter)
        {
            this.dataContractConverter = dataContractConverter;
        }

        /// <inheritdoc />
        TValue IConverter<IResponse<TDataContract>, TValue>.Convert(IResponse<TDataContract> value)
        {
            var dataContract = value.Content;

            // Check if the dataContract is empty and return the default value fot TValue
            // ReSharper disable once RedundantNameQualifier
            if (Equals(dataContract, default(TDataContract)))
            {
                return default(TValue);
            }

            // Convert the item.
            var item = this.dataContractConverter.Convert(dataContract);

            // Set tzhe localizsation of the item.
            var localizableItem = item as ILocalizable;
            if (localizableItem != null)
            {
                localizableItem.Culture = value.Culture;
            }

            // Set the time of the item.
            var timesensitiveItem = item as ITimeSensitive;
            if (timesensitiveItem != null)
            {
                timesensitiveItem.Timestamp = value.Date;
            }

            // Return the item itself.
            return item;
        }
    }
}