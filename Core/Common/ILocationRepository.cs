// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILocationRepository.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides the interface for a location repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System;
    using RpgTools.Core.Models.Locations;

    /// <summary>Provides the interface for a location repository.</summary>
    public interface ILocationRepository : IRepository<Guid, Location>, ILocalizable, IWriteable<Location>
    {
    }
}