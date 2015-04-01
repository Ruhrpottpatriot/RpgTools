// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationDetailsRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the LocationDetailsRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using RpgTools.Locations.DataContracts;

    /// <summary>Represents a location detail request against a database.</summary>
    internal sealed class LocationDetailsRequest : DetailsDatabaseRequest<LocationDataContract>
    {
        /// <summary>Gets the resource to query.</summary>
        public override Expression<Func<DbContext, LocationDataContract>> Resource
        {
            get
            {
                return s => s.Set<LocationDataContract>().Include(ld => ld.Details).Single(l => l.Id == this.Identifier);
            }
        }
    }
}