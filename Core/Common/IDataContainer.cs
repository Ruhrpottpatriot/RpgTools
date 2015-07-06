// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IResponse.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Provides the interface for service responses.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System;

    /// <summary>Provides the interface for service responses.</summary>
    /// <typeparam name="T">The type of the response content.</typeparam>
    public interface IDataContainer<T> : ILocalizable
    {
        /// <summary>Gets or sets the response content.</summary>
        T Content { get; set; }

        /// <summary>Gets or sets the <see cref="DateTimeOffset"/> at which the message originated..</summary>
        DateTimeOffset? Date { get; set; }
    }
}