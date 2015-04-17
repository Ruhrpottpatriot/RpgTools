// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDiscoverable.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Provides the interface for data sources that support enumerating object identifiers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the interface for data sources that support enumerating object identifiers.</summary>
    /// <typeparam name="TKey">The type of the identifiers.</typeparam>
    public interface IDiscoverable<TKey>
    {
        /// <summary>Discovers identifiers of objects in the data source.</summary>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of object identifiers.</returns>
        ICollection<TKey> Discover();

        /// <summary>Discovers identifiers of objects in the data source.</summary>
        /// <exception cref="NotSupportedException">The data source does not support the discovery of object identifiers.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of object identifiers.</returns>
        Task<ICollection<TKey>> DiscoverAsync();

        /// <summary>Discovers identifiers of objects in the data source.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not support the discovery of object identifiers.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>A collection of object identifiers.</returns>
        Task<ICollection<TKey>> DiscoverAsync(CancellationToken cancellationToken);
    }
}