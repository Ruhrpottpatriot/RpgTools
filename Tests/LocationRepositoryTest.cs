// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationRepositoryTest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the LocationRepositoryTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tests
{
    using System;
    using System.Data.Entity.Spatial;
    using System.Diagnostics;
    
    using NUnit.Framework;

    using RpgTools.Core.Common;
    using RpgTools.Core.Models.Locations;
    using RpgTools.Locations;

    [TestFixture]
    public class LocationRepositoryTest
    {
        private ILocationRepository locationRepository;

        [SetUp]
        public void SetUp()
        {
            this.locationRepository = new LocationRepository();
        }

        [Test]
        public void DiscoverTest()
        {
            var ids = this.locationRepository.Discover();

            Debug.Write(string.Format("Id Count: {0}", ids.Count));
        }

        [Test]
        public void DiscoverAsync()
        {
        }

        [Test]
        public void DiscoverAsyncWithCancellationTokenTest()
        {
        }

        [Test]
        public void FindTest()
        {
        }

        [Test]
        public void FindCollectionTest()
        {
        }

        [Test]
        public void FindAllTest()
        {
        }

        [Test]
        public void WriteTest()
        {
            ILocationRepository repository = new LocationRepository();

            var location = new City
                               {
                                   Coordinates = ConvertLatLonToDbGeography(1, 5),
                                   Description = "Test",
                                   Id = Guid.NewGuid(),
                                   Population = 10023,
                                   IsCapital = false,
                                   Name = "Stromsang",
                                   Planet = null
                               };

            repository.Write(location);
        }

        public static DbGeography ConvertLatLonToDbGeography(double longitude, double latitude)
        {
            var point = string.Format("POINT({1} {0})", latitude, longitude);
            return DbGeography.FromText(point);
        }
    }
}
