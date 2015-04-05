// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWriteableServiceClient.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Provides the interface for a create-read-update service client.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System.Threading;
    using System.Threading.Tasks;
    using RpgTools.Core.Common.Requests;

    /// <summary>Provides the interface for a create-read-update service client.</summary>
    public interface IWriteableServiceClient : IServiceClient
    {
        /// <summary>Writes the specified data to the implementation specific data source.</summary>
        /// <param name="request">An <see cref="IRequest"/> containing the data to be written to the data source.</param>
        void Create(IRequest request);

        /// <summary>Asynchronously writes the specified data to the implementation specific data source.</summary>
        /// <param name="request">An <see cref="IRequest"/> containing the data to be written to the data source.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task CreateAsync(IRequest request);

        /// <summary>Asynchronously writes the specified data to the implementation specific data source.</summary>
        /// <param name="request">An <see cref="IRequest"/> containing the data to be written to the data source.</param>
        /// <param name="cancellationToken">A token signalling the cancellation of the operation.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task CreateAsync(IRequest request, CancellationToken cancellationToken);

        /// <summary>Updates the specified data in the implementation specific data source.</summary>
        /// <param name="request">An <see cref="IRequest"/> containing the data to be updated.</param>
        /// <typeparam name="TData">The type of data that is being written to the data source.</typeparam>
        void Update<TData>(IRequest request);

        /// <summary>Asynchronously updates the specified data in the implementation specific data source.</summary>
        /// <param name="request">An <see cref="IRequest"/> containing the data to be updated.</param>
        /// <typeparam name="TData">The type of data that is being written to the data source.</typeparam>
        /// <returns>A <see cref="Task"/>.</returns>
        Task UpdateAsync<TData>(IRequest request);

        /// <summary>Asynchronously updates the specified data in the implementation specific data source.</summary>
        /// <param name="request">An <see cref="IRequest"/> containing the data to be updated.</param>
        /// <param name="cancellationToken">A token signalling the cancellation of the operation.</param>
        /// <typeparam name="TData">The type of data that is being written to the data source.</typeparam>
        /// <returns>A <see cref="Task"/>.</returns>
        Task UpdateAsync<TData>(IRequest request, CancellationToken cancellationToken);
    }
}