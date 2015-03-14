// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    /// <summary>Provides the base interface for all requests.</summary>
    /// <typeparam name="TData">The resource data.</typeparam>
    public interface IRequest<out TData>
    {
        /// <summary>Gets the resource.</summary>
        TData Resource { get; }
    }
}
