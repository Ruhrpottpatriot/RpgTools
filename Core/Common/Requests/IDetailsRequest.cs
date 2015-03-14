// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDetailsRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides the interface for a details request against a database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    /// <summary>Provides the interface for a details request.</summary>
    /// <typeparam name="TData">The resource type.</typeparam>
    /// <typeparam name="TIdentifier">The identifier to identify the data.</typeparam>
    public interface IDetailsRequest<out TData, TIdentifier> : IRequest<TData>
    {
        /// <summary>Gets or sets the data identifier.</summary>
        TIdentifier Identifier { get; set; }
    }
}