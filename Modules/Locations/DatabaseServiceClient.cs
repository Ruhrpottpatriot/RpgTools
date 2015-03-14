// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseServiceClient.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the DatabaseServiceClient type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using RpgTools.Core.Common;
    using RpgTools.Core.Common.Requests;

    public class DatabaseServiceClient<TContext>
    {
        private readonly TContext context;

        public DatabaseServiceClient(TContext context)
        {
            this.context = context;
        }

        public IResponse<TResult> Query<TResult>(IRequest<Func<TContext, TResult>> request)
        {
            var selector = request.Resource;

            return new Response<TResult> { Content = selector(this.context) };
        }

        public Task<IResponse<TResult>> QueryAsync<TResult>(IRequest<Func<TContext, TResult>> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Send(Action<TContext> expression)
        {
            expression(this.context);
        }
    }
}