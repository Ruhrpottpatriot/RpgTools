// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationDetailViewModel.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the LocationDetailViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.LocationPresenter.ViewModels
{
    using System;
    using System.ComponentModel.Composition;
    using System.Data.Entity.Spatial;
    using Caliburn.Micro;
    using PropertyChanged;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;
    using RpgTools.Core.Models.Locations;

    [ImplementPropertyChanged]
    public class LocationDetailViewModel : Screen
    {
        private readonly IEventAggregator eventAggregator;

        private readonly IWindowManager windowManager;

        private readonly ILocationRepository locationRepository;
        
        public LocationDetailViewModel()
        {
            if (Execute.InDesignMode)
            {
                this.Location = new City
                                {
                                    Coordinates = DbGeography.FromText("POINT(-117.861328 34.089061)"),
                                    Description = "Stromsang City",
                                    Id = Guid.NewGuid(),
                                    IsCapital = false,
                                    Name = "Stromsang",
                                    PlanetId = Guid.NewGuid(),
                                    Population = 30900
                                };
            }
        }

        [ImportingConstructor]
        public LocationDetailViewModel(IEventAggregator eventAggregator, IWindowManager windowManager, ILocationRepository locationRepository)
        {
            this.eventAggregator = eventAggregator;
            this.windowManager = windowManager;
            this.locationRepository = locationRepository;
        }

        public Location Location { get; set; }

        public override string DisplayName
        {
            get
            {
                return this.Location.Name;
            }
        }

        public string Type
        {
            get
            {
                if (Execute.InDesignMode)
                {
                    return "City";
                }

                return this.Location.GetType().Name;
            }
        }
    }

    public enum LocationType
    {
        City,
        Planet,
        StarSystem,
        Sector
    }
}