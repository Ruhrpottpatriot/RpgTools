// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationWriteRequest.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations.Requests
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq.Expressions;
    using RpgTools.Core.Common.Requests;
    using RpgTools.Locations.DataContracts;

    /// <summary>Represents a request to write data into the database.</summary>
    internal class LocationWriteRequest : IDatabaseRequest<Action<DbContext>>
    {
        /// <summary>
        /// Gets the resource.
        /// </summary>
        public Expression<Action<DbContext>> Resource
        {
            get
            {
                return c => c.Set<LocationDataContract>().AddOrUpdate(this.Data);
            }
        }

        /// <summary>Gets or sets the context.</summary>
        public DbContext Context { get; set; }

        /// <summary>Gets or sets the data that is being written..</summary>
        public LocationDataContract Data { get; set; }
    }
}
