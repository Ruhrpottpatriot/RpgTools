// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataContainer.cs" company="Robert Logiewa">
// (C) All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System;

    /// <summary>Provides the interface for data that is moved around the application.</summary>
    /// <typeparam name="TData">The type of the content.</typeparam>
    public interface IDataContainer<TData> : ILocalizable
    {
        /// <summary>Gets or sets the response content.</summary>
        TData Content { get; set; }

        /// <summary>Gets or sets the <see cref="DateTimeOffset"/> at which the message originated.</summary>
        DateTimeOffset? Date { get; set; }
    }
}