// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICompleteRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides the interface for a complete database context query.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    /// <summary>Provides the interface for a complete query.</summary>
    /// <typeparam name="TData">The type of data to return.</typeparam>
    public interface ICompleteRequest<out TData> : IRequest<TData>
    {
    }
}