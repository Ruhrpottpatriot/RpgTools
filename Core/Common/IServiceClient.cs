// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceClient.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides the interface for a read-only service client.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System.Threading;
    using System.Threading.Tasks;
    using RpgTools.Core.Common.Requests;

    /// <summary>Provides the interface for a read-only service client.</summary>
    public interface IServiceClient
    {
        /// <summary>Reads data from the implementation specific data source.</summary>
        /// <param name="request">Contains data to perform the request against the data source.</param>
        /// <typeparam name="TData">The type of data that should be returned.</typeparam>
        /// <returns>An <see cref="IResponse{T}"/> containing the data of type <see cref="TData"/>.</returns>
        IResponse<TData> Read<TData>(IRequest request);

        /// <summary>Asynchronously reads data from the implementation specific data source.</summary>
        /// <param name="request">Contains data to perform the request against the data source.</param>
        /// <typeparam name="TData">The type of data that should be returned.</typeparam>
        /// <returns>A <see cref="Task{TResult}"/> with the <see cref="IResponse{TResult}"/> that holds the data of type <see cref="TData"/>.</returns>
        Task<IResponse<TData>> ReadAsync<TData>(IRequest request);

        /// <summary>Asynchronously reads data from the implementation specific data source.</summary>
        /// <param name="request">Contains data to perform the request against the data source.</param>
        /// <param name="cancellationToken">A token signalling the cancellation of the operation.</param>
        /// <typeparam name="TData">The type of data that should be returned.</typeparam>
        /// <returns>A <see cref="Task{TResult}"/> with the <see cref="IResponse{TResult}"/> that holds the data of type <see cref="TData"/>.</returns>
        Task<IResponse<TData>> ReadAsync<TData>(IRequest request, CancellationToken cancellationToken);
    }
}