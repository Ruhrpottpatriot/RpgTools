// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationsViewModel.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the LocationsViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Main.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Windows;

    using Caliburn.Micro;

    using PropertyChanged;

    using RpgTools.Core.Common;
    using RpgTools.Core.Contracts;
    using RpgTools.Locations;

    [ImplementPropertyChanged]
    [RpgModuleMetadata(Name = "Locations")]
    [Export(typeof(IRpgModuleContract))]
    public class LocationsViewModel : Conductor<Screen>.Collection.OneActive, IRpgModuleContract
    {
        private ILocationRepository locationRepository;

        private IWindowManager windowManager;

        private IEventAggregator eventAggregator;

        public LocationsViewModel()
        {
        }

        [ImportingConstructor]
        public LocationsViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            if (Execute.InDesignMode)
            {
                this.Ids = new List<Guid> { Guid.NewGuid() };
            }

            this.locationRepository = new LocationRepository();
        }

        public void LoadIds()
        {
            this.Ids = this.locationRepository.Discover();
        }

        public Visibility TabControlVisibility { get; set; }

        public ICollection<Guid> Ids { get; set; }

        public void OpenTab(Guid identifier)
        {
            var location = this.locationRepository.Find(identifier);

            if (this.Items.All(s => s.DisplayName != location.Name) && location != null)
            {
                // Make the tab control viosible to the user.
                this.TabControlVisibility = Visibility.Visible;

                // Create a new view model to show the data.
                LocationDetailViewModel locationDetail = new LocationDetailViewModel(this.eventAggregator, this.windowManager, this.locationRepository) { Location = location };

                // Activate the item.
                this.ActivateItem(locationDetail);
            }

        }

        public void CloseTab(object dataContext)
        {
            this.CloseItem(dataContext);

            if (!this.Items.Any())
            {
                this.TabControlVisibility = Visibility.Collapsed;
            }
        }
    }
}
