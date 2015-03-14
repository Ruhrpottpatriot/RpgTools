// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationBulkDatabaseRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides methods an properties to query a number of locations from the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using RpgTools.Core.Common.Requests;
    using RpgTools.Locations;
    using RpgTools.Locations.DataContracts;

    /// <summary>Provides methods an properties to query a number of locations from the database.</summary>
    internal sealed class LocationBulkDatabaseRequest : BulkDatabaseRequest<LocationContext, ICollection<LocationDataContract>, Guid>
    {
        /// <inheritdoc />
        public override Func<LocationContext, ICollection<LocationDataContract>> Resource
        {
            get
            {
                return c => c.Locations.Where(p => this.Identifiers.Any(f => f == p.Id)).ToList();
            }
        }
    }
}