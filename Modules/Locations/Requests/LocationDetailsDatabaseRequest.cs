namespace RpgTools.Locations.Requests
{
    using System;
    using System.Linq;

    using RpgTools.Core.Common.Requests;
    using RpgTools.Locations;
    using RpgTools.Locations.DataContracts;

    /// <summary>Provides methods and properties to query location details from a database.</summary>
    internal sealed class LocationDetailsDatabaseRequest : DetailsDatabaseRequest<LocationContext, LocationDataContract, Guid>
    {
        /// <inheritdoc />
        public override Func<LocationContext, LocationDataContract> Resource
        {
            get
            {
                return c => c.Locations.SingleOrDefault(l => l.Id == this.Identifier);
            }
        }
    }
}