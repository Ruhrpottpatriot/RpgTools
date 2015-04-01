// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationCompleteRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the LocationCompleteRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using RpgTools.Locations.DataContracts;

    /// <summary>Represents a location request against a database that returns all records.</summary>
    internal class LocationCompleteRequest : CompleteDatabaseRequest<ICollection<LocationDataContract>>
    {
        /// <summary>Gets the resource to query.</summary>
        public override Expression<Func<DbContext, ICollection<LocationDataContract>>> Resource
        {
            get
            {
                return c => c.Set<LocationDataContract>().Include(r => r.Details).ToList();
            }
        }
    }
}