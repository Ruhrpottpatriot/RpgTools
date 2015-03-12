// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationDetailViewModel.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the LocationDetailViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Main.ViewModels
{
    using Caliburn.Micro;
    using PropertyChanged;

    using RpgTools.Core.Common;
    using RpgTools.Core.Models.Locations;

    public class LocationDetailViewModel : Screen
    {
        private readonly IEventAggregator eventAggregator;

        private readonly IWindowManager windowManager;

        private readonly ILocationRepository locationRepository;


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
    }
}