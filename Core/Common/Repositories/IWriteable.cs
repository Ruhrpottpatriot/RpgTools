// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWriteable.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   provides the interface for a writeable repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    /// <summary>provides the interface for a writeable repository.</summary>
    /// <typeparam name="TData">The type of the data to be written.</typeparam>
    public interface IWriteable<in TData>
    {
        /// <summary>Writes the data to the repository.</summary>
        /// <param name="data">The data to write.</param>
        void Write(TData data);

        /// <summary>Deletes a specific item from the database.</summary>
        /// <param name="data">The item to delete.</param>
        void Delete(TData data);
    }
}
