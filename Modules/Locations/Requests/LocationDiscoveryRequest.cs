// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationDiscoveryRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Represents a discovery request for all location ids.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using RpgTools.Core.Common.Requests;
    using RpgTools.Locations.DataContracts;

    /// <summary>Represents a discovery request for all location ids.</summary>
    internal class LocationDiscoveryRequest : IDatabaseRequest<Func<DbContext, ICollection<Guid>>>
    {
        /// <summary>Gets the resource to query.</summary>
        public Expression<Func<DbContext, ICollection<Guid>>> Resource
        {
            get
            {
                return s => s.Set<LocationDataContract>().Select(l => l.Id).ToList();
            }
        }

        /// <summary>Gets or sets the database context.</summary>
        public DbContext Context { get; set; }
    }
}