// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseSeviceClient.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   A service client used to query a database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations
{
    using System;
    using System.Data.Entity;
    using System.Threading;
    using System.Threading.Tasks;

    using RpgTools.Core.Common;

    /// <summary>A Service client that queries a database provided by the request.</summary>
    public class DatabaseSeviceClient : IAuthorizedServiceClient
    {
        /// <summary>Queries the database with the specified request.</summary>
        /// <param name="request">The request to query the database. See <see cref="IRequest"/> for more information.</param>
        /// <typeparam name="TData">The type of data to return.</typeparam>
        /// <returns>A response of type <see cref="IResponse{T}"/> encapsulating the data that is returned.</returns>
        public IResponse<TData> Read<TData>(IRequest request)
        {
            var databaseRequest = (IDatabaseRequest<Func<DbContext, TData>>)request;

            var returnVal = databaseRequest.Resource.Compile().Invoke(databaseRequest.Context);

            return new Response<TData> { Content = returnVal };
        }

        /// <summary>Asynchronously reads data from the implementation specific data source.</summary>
        /// <param name="request">Contains data to perform the request against the data source.</param>
        /// <typeparam name="TData">The type of data that should be returned.</typeparam>
        /// <returns>A <see cref="Task{TResult}"/> with the <see cref="IResponse{TResult}"/> that holds the data of type <see cref="TData"/>.</returns>
        /// <exception cref="NotSupportedException">The current version of the DatabaseServiceClient does not support asynchronous operations.</exception>
        public Task<IResponse<TData>> ReadAsync<TData>(IRequest request)
        {
            return this.ReadAsync<TData>(request, CancellationToken.None);
        }

        /// <summary>Asynchronously queries the database with the specified request.</summary>
        /// <param name="request">The request to query the database. See <see cref="IRequest"/> for more information.</param>
        /// <param name="cancellationToken">The token to cancel the operation.</param>
        /// <typeparam name="TData">The type of data to return.</typeparam>
        /// <returns>A response of type <see cref="IResponse{T}"/> encapsulating the data that is returned.</returns>
        /// <exception cref="NotSupportedException">The current version of the DatabaseServiceClient does not support asynchronous operations.</exception>
        public Task<IResponse<TData>> ReadAsync<TData>(IRequest request, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("The current implementation of the DatabaseServiceClient does not support asynchronous operations.");
        }

        /// <summary>Writes the specified data to the implementation specific data source.</summary>
        /// <param name="request">An <see cref="IRequest"/> containing the data to be written to the data source.</param>
        public void Create(IRequest request)
        {
            var writeRequest = (IDatabaseRequest<Action<DbContext>>)request;

            writeRequest.Resource.Compile().Invoke(writeRequest.Context);

            writeRequest.Context.SaveChanges();
        }

        /// <summary>Asynchronously writes the specified data to the implementation specific data source.</summary>
        /// <param name="request">An <see cref="IRequest"/> containing the data to be written to the data source.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        /// <exception cref="NotSupportedException">The current version of the DatabaseServiceClient does not support asynchronous operations.</exception>
        public Task CreateAsync(IRequest request)
        {
            return this.CreateAsync(request, CancellationToken.None);
        }

        /// <summary>Asynchronously writes the specified data to the implementation specific data source.</summary>
        /// <param name="request">An <see cref="IRequest"/> containing the data to be written to the data source.</param>
        /// <param name="cancellationToken">A token signalling the cancellation of the operation.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        /// <exception cref="NotSupportedException">The current version of the DatabaseServiceClient does not support asynchronous operations.</exception>
        public Task CreateAsync(IRequest request, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("The current implementation of the DatabaseServiceClient does not support asynchronous calls");
        }

        /// <summary>Updates the specified data in the implementation specific data source.</summary>
        /// <param name="request">An <see cref="IRequest"/> containing the data to be updated.</param>
        /// <typeparam name="TData">The type of data that should be returned.</typeparam>
        public void Update<TData>(IRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>Asynchronously updates the specified data in the implementation specific data source.</summary>
        /// <param name="request">An <see cref="IRequest"/> containing the data to be updated.</param>
        /// <typeparam name="TData">The type of data that should be returned.</typeparam>
        /// <returns>A <see cref="Task"/>.</returns>
        /// <exception cref="NotSupportedException">The current version of the DatabaseServiceClient does not support asynchronous operations.</exception>
        public Task UpdateAsync<TData>(IRequest request)
        {
            return this.UpdateAsync<TData>(request, CancellationToken.None);
        }

        /// <summary>Asynchronously updates the specified data in the implementation specific data source.</summary>
        /// <param name="request">An <see cref="IRequest"/> containing the data to be updated.</param>
        /// <param name="cancellationToken">A token signalling the cancellation of the operation.</param>
        /// <typeparam name="TData">The type of data that should be returned.</typeparam>
        /// <returns>A <see cref="Task"/>.</returns>
        /// <exception cref="NotSupportedException">The current version of the DatabaseServiceClient does not support asynchronous operations.</exception>
        public Task UpdateAsync<TData>(IRequest request, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("The current implementation of the DatabaseServiceClient does not support asynchronous calls");
        }

        /// <summary>Tries to delete a record from the implementation specific data source.</summary>
        /// <param name="request">The <see cref="IRequest"/> containing the data to delete.</param>
        /// <returns>A <see cref="bool"/> indicating whether the delete was successful.</returns>
        public bool TryDelete(IRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>Asynchronously tries to delete a record from the implementation specific data source.</summary>
        /// <param name="request">The <see cref="IRequest"/> containing the data to delete.</param>
        /// <returns>A <see cref="Task{TResult}"/> containing a <see cref="bool"/> indicating whether the delete was successful.</returns>
        /// <exception cref="NotSupportedException">The current version of the DatabaseServiceClient does not support asynchronous operations.</exception>
        public Task<bool> TryDeleteAsync(IRequest request)
        {
            return this.TryDeleteAsync(request, CancellationToken.None);
        }

        /// <summary>Asynchronously tries to delete a record from the implementation specific data source.</summary>
        /// <param name="request">The <see cref="IRequest"/> containing the data to delete.</param>
        /// <param name="cancellationToken">A token signalling the cancellation of the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> containing a <see cref="bool"/> indicating whether the delete was successful.</returns>
        /// <exception cref="NotSupportedException">The current version of the DatabaseServiceClient does not support asynchronous operations.</exception>
        public Task<bool> TryDeleteAsync(IRequest request, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("The current implementation of the DatabaseServiceClient does not support asynchronous calls");
        }
    }
}