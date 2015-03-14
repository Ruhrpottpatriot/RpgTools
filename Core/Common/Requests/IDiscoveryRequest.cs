// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDiscoveryRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides the base interface for all discovery requests against a database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    /// <summary>Provides the base interface for all discovery requests against a database.</summary>
    /// <typeparam name="TData">The type of data to return.</typeparam>
    public interface IDiscoveryRequest<out TData> : IRequest<TData>
    {
    }
}