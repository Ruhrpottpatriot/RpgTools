// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDatabaseRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the IDatabaseRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    using System;

    /// <summary>Provides the base interface for all requests against a database.</summary>
    /// <typeparam name="TContext">The database context.</typeparam>
    /// <typeparam name="TReturn">The type of data to return.</typeparam>
    public interface IDatabaseRequest<in TContext, out TReturn> : IRequest<Func<TContext, TReturn>>
    {
    }
}