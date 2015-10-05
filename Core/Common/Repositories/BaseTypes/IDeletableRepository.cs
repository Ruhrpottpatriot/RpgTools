// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDeletableRepository.cs" company="Robert Logiewa">
// (C) All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the interface to delete data in a repository.</summary>
    /// <typeparam name="TIdentifier">The identifier of the data to delete.</typeparam>
    public interface IDeletableRepository<in TIdentifier>
    {
        /// <summary>Deletes an item in the repository.</summary>
        /// <param name="identifier">The identifier that uniquely identifies an item in the repository.</param>
        Task DeleteAsync(TIdentifier identifier);

        /// <summary>Deletes an item in the repository.</summary>
        /// <param name="identifier">The identifier that uniquely identifies an item in the repository.</param>
        /// <param name="cancellationToken">A token, that signals the cancellation of the operation.</param>
        Task DeleteAsync(TIdentifier identifier, CancellationToken cancellationToken);
    }
}