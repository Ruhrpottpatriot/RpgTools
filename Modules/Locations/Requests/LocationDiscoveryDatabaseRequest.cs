// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationDiscoveryDatabaseRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides methods and properties to query identifiers from the location database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using RpgTools.Core.Common.Requests;
    using RpgTools.Locations;

    /// <summary>Provides methods and properties to query identifiers from the location database.</summary>
    internal sealed class LocationDiscoveryDatabaseRequest : DiscoveryDatabaseRequest<LocationContext, ICollection<Guid>>
    {
        /// <inheritdoc />
        public override Func<LocationContext, ICollection<Guid>> Resource
        {
            get
            {
                return c => c.Locations.Select(i => i.Id).ToList();
            }
        }
    }
}