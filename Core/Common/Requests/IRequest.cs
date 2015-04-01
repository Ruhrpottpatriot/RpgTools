// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the IRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    /// <summary>Interface for requests against an arbitrary data source.</summary>
    /// <remarks>This interface does actually nothing. However the <see cref="IServiceClient"/> interface and its implementations expect an IRequest.
    /// Therefore all requests have to implement this interface and the appropriate casting has to be done inside the <see cref="IServiceClient"/> implementation.</remarks>
    public interface IRequest
    {
    }
}