namespace RpgTools.Locations.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using RpgTools.Core.Common.Requests;
    using RpgTools.Locations;
    using RpgTools.Locations.DataContracts;

    /// <summary>Provides methods and properties to query location details from a database.</summary>
    internal sealed class LocationDatabaseDetailsRequest : DatabaseDetailsRequest<LocationContext, LocationDataContract, Guid>
    {
        /// <inheritdoc />
        public override Func<LocationContext, LocationDataContract> Resource
        {
            get
            {
                return c => c.Locations.SingleOrDefault(i => i.Id == this.Identifier);

                //return
                //    c =>
                //    c.Locations.Select(
                //        l =>
                //        new LocationDataContract
                //        {
                //            Id = l.Id,
                //            Coordinates = l.Coordinates,
                //            Description = l.Description,
                //            Name = l.Name,
                //            Type = l.Type,
                //            Details = this.GetDetails(l.Type, c)
                //        }).SingleOrDefault(i => i.Id == this.Identifier);
            }
        }

        private LocationDetailsDataContract GetDetails(string detailsType, LocationContext locationContext)
        {
            switch (detailsType)
            {
                case "City":
                    return locationContext.Set<CityDetailsDataContract>().SingleOrDefault(i => i.Id == this.Identifier);
                case "Planet":
                    return locationContext.Set<PlanetDetailsDataContract>().SingleOrDefault(i => i.Id == this.Identifier);
                case "StarSystem":
                    return locationContext.Set<StarSystemDetailsDataContract>().SingleOrDefault(i => i.Id == this.Identifier);
                case "Sector":
                    return locationContext.Set<SectorDetailsDataContract>().SingleOrDefault(i => i.Id == this.Identifier);
                default:
                    return null;
            }
        }

        private Dictionary<string, LocationDetailsDataContract> GetKnowDbSets(LocationContext locationContext)
        {
            return new Dictionary<string, LocationDetailsDataContract>
                           {
                               { "City", locationContext.Set<CityDetailsDataContract>().SingleOrDefault(t => t.Id == this.Identifier) },
                               { "Planet", locationContext.Set<PlanetDetailsDataContract>().SingleOrDefault(t => t.Id == this.Identifier) },
                               { "StarSystem", locationContext.Set<StarSystemDetailsDataContract>().SingleOrDefault(t => t.Id == this.Identifier) },
                               { "Sector", locationContext.Set<SectorDetailsDataContract>().SingleOrDefault(t => t.Id == this.Identifier) }
                           };
        }
    }
}