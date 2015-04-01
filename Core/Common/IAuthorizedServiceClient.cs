// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAuthorizedServiceClient.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides the interface for a create-write-update-delete service client.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System.Threading;
    using System.Threading.Tasks;
    using RpgTools.Core.Common.Requests;

    /// <summary>Provides the interface for a create-write-update-delete service client.</summary>
    public interface IAuthorizedServiceClient : IWriteableServiceClient
    {
        /// <summary>Tries to delete a record from the implementation specific data source.</summary>
        /// <param name="request">The <see cref="IRequest"/> containing the data to delete.</param>
        /// <returns>A <see cref="bool"/> indicating whether the delete was successful.</returns>
        bool TryDelete(IRequest request);

        /// <summary>Asynchronously tries to delete a record from the implementation specific data source.</summary>
        /// <param name="request">The <see cref="IRequest"/> containing the data to delete.</param>
        /// <returns>A <see cref="Task{TResult}"/> containing a <see cref="bool"/> indicating whether the delete was successful.</returns>
        Task<bool> TryDeleteAsync(IRequest request);
        
        /// <summary>Asynchronously tries to delete a record from the implementation specific data source.</summary>
        /// <param name="request">The <see cref="IRequest"/> containing the data to delete.</param>
        /// <param name="cancellationToken">A token signalling the cancellation of the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> containing a <see cref="bool"/> indicating whether the delete was successful.</returns>
        Task<bool> TryDeleteAsync(IRequest request, CancellationToken cancellationToken);
    }
}