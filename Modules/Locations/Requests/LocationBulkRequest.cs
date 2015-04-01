namespace RpgTools.Locations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using RpgTools.Core.Common.Requests;
    using RpgTools.Locations.DataContracts;

    /// <summary>Represents a bulk request for locations against a database.</summary>
    internal class LocationBulkRequest : BulkDatabaseRequest<ICollection<LocationDataContract>>
    {
        /// <summary>Gets the resource to query.</summary>
        public override Expression<Func<DbContext, ICollection<LocationDataContract>>> Resource
        {
            get
            {
                return c => c.Set<LocationDataContract>().Include(ld => ld.Details).Where(l => this.Identifiers.Any(i => i == l.Id)).ToList();
            }
        }
    }
}