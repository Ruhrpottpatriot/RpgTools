// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationDeleteRequest.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the LocationDeleteRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations.Requests
{
    using System;
    using System.Data.Entity;
    using System.Linq.Expressions;
    using RpgTools.Core.Common.Requests;
    using RpgTools.Locations.DataContracts;

    /// <summary>Represents a request to delete data from the database.</summary>
    internal class LocationDeleteRequest : DeleteDatabaseRequest<LocationDataContract>
    {
        /// <summary>Gets the resource to query.</summary>
        public override Expression<Action<DbContext>> Resource
        {
            get
            {
                return c => c.Set<LocationDataContract>().Remove(this.Location);
            }
        }
    }
}