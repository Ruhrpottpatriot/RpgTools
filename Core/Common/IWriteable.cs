// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWriteable.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   provides the interface for a writeable repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System.Threading;

    /// <summary>provides the interface for a writeable repository.</summary>
    /// <typeparam name="TData">The type of the data to be written.</typeparam>
    public interface IWriteable<in TData>
    {
        /// <summary>Writes the data to the repository.</summary>
        /// <param name="data">The data to write.</param>
        void Write(TData data);

        /// <summary>Writes the data to the repository asynchronously.</summary>
        /// <param name="data">The data to write.</param>
        void WriteAsync(TData data);

        /// <summary>Writes the data to the repository asynchronously.</summary>
        /// <param name="data">The data to write.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        void WriteAsync(TData data, CancellationToken cancellationToken);

        /// <summary>Deletes a specific item from the database.</summary>
        /// <param name="data">The item to delete.</param>
        void Delete(TData data);

        /// <summary>Asynchronously deletes a specific item from the database.</summary>
        /// <param name="data">The item to delete.</param>
        void DeleteAsync(TData data);

        /// <summary>Asynchronously deletes a specific item from the database.</summary>
        /// <param name="data">The item to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        void DeleteAsync(TData data, CancellationToken cancellationToken);
    }
}
