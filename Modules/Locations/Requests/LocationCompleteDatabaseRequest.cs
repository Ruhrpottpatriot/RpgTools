// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationCompleteDatabaseRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides methods and properties to query a location <see cref="DbSet" /> from a database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using RpgTools.Core.Common.Requests;
    using RpgTools.Locations.DataContracts;

    /// <summary>Provides methods and properties to query a location <see cref="DbSet"/> from a database.</summary>
    internal sealed class LocationCompleteDatabaseRequest : CompleteDatabaseRequest<LocationContext, ICollection<LocationDataContract>>
    {
        /// <inheritdoc />
        public override Func<LocationContext, ICollection<LocationDataContract>> Resource
        {
            get
            {
                return c => c.Locations.ToList();
            }
        }
    }
}