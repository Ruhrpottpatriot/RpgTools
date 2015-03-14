// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseServiceClient.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the DatabaseServiceClient type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using RpgTools.Core.Common.Requests;

    /// <summary>Service client to perform CRUD actions on a database.</summary>
    /// <typeparam name="TContext">The type of the database context.</typeparam>
    public class DatabaseServiceClient<TContext>
    {
        /// <summary>Infrastructure. Holds a reference to the database context.</summary>
        private readonly TContext context;

        /// <summary>Initialises a new instance of the <see cref="DatabaseServiceClient{TContext}"/> class.</summary>
        /// <param name="context">The database context.</param>
        public DatabaseServiceClient(TContext context)
        {
            this.context = context;
        }

        /// <summary>Queries a database with the specified request.</summary>
        /// <param name="request">The request to perform on the database.</param>
        /// <typeparam name="TResult">The type of result to return.</typeparam>
        /// <returns>A <see cref="IResponse{TResult}"/> containing the data from the database. </returns>
        public IResponse<TResult> Query<TResult>(IRequest<Func<TContext, TResult>> request)
        {
            var selector = request.Resource;

            return new Response<TResult>
                       {
                           Content = selector(this.context),
                           Date = DateTime.UtcNow
                       };
        }

        /// <summary>Asynchronously queries a database with the specified request.</summary>
        /// <param name="request">The request to perform on the database.</param>
        /// <param name="cancellationToken">The token that cancels the operation.</param>
        /// <typeparam name="TResult">The type of result to return.</typeparam>
        /// <returns>A <see cref="Task{T}"/> containing the <see cref="IResponse{TResult}"/> with the data from the database. </returns>
        public Task<IResponse<TResult>> QueryAsync<TResult>(IRequest<Func<TContext, TResult>> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>Performs a write/update operation on the database.</summary>
        /// <param name="action">The action to perform on the database.</param>
        public void Send(Action<TContext> action)
        {
            action(this.context);
        }
    }
}