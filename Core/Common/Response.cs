// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Response.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the Response type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System;
    using System.Globalization;

    /// <summary>Provides the default implementation of the <see cref="IResponse{T}"/> interface.</summary>
    /// <typeparam name="T">The type of the response content.</typeparam>
    public class Response<T> : IResponse<T>
    {
        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets or sets the response content.</summary>
        public T Content { get; set; }

        /// <summary>Gets or sets the time the response originated (in UTC).</summary>
        public DateTimeOffset? Date { get; set; }
    }
}