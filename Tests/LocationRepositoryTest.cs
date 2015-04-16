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
    using System.Diagnostics;
    
    using NUnit.Framework;

    using RpgTools.Core.Common;
    using RpgTools.Core.Models;
    using RpgTools.Locations;

    [TestFixture]
    public class LocationRepositoryTest
    {
        private ILocationRepository locationRepository;

        [SetUp]
        public void SetUp()
        {
            this.locationRepository = new LocationRepositoryFactory(new DatabaseSeviceClient()).ForDefaultCulture();
        }

        [Test]
        public void DiscoverTest()
        {
            var ids = this.locationRepository.Discover();

            Debug.Write(string.Format("Id Count: {0}", ids.Count));
        }
        
        [Test]
        public void FindTest()
        {
            var loc = this.locationRepository.Find(new Guid("df922009-3611-4faf-85b4-3e78f55113f6"));

            Debug.WriteLine(loc.Name);
        }

        [Test]
        public void WriteTest()
        {
            var location = new Location
                           {
                               Coordinates = null,
                               Description = "Arbitrary Description",
                               Id = Guid.NewGuid(),
                               Name = "Some location"
                           };

            this.locationRepository.Write(location);
        }
    }
}
