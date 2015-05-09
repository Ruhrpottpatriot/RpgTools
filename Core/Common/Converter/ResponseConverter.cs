// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponseConverter.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Core.Common.Converter
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
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
            Contract.Requires(dataContractConverter != null);
            this.dataContractConverter = dataContractConverter;
        }

        /// <inheritdoc />
        TValue IConverter<IResponse<TDataContract>, TValue>.Convert(IResponse<TDataContract> value)
        {
            Contract.Assume(value != null);

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

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.dataContractConverter != null);
        }
    }
}