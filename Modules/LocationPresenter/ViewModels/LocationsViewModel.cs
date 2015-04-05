// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationsViewModel.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the LocationsViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.LocationPresenter.ViewModels
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
    using RpgTools.Core.Models.Locations;
    using RpgTools.Locations;

    /// <summary>Represents the location view model.</summary>
    [ImplementPropertyChanged]
    [RpgModuleMetadata(Name = "Locations")]
    [Export(typeof(IRpgModuleContract))]
    public class LocationsViewModel : Conductor<Screen>.Collection.OneActive, IRpgModuleContract
    {
        /// <summary>Infrastructure. Holds a reference to the  location repository.</summary>
        private readonly ILocationRepository locationRepository;

        /// <summary>Infrastructure. Holds a reference to the  window manager.</summary>
        private readonly IWindowManager windowManager;

        /// <summary>Infrastructure. Holds a reference to the event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>Initialises a new instance of the <see cref="LocationsViewModel"/> class.</summary>
        public LocationsViewModel()
        {
        }

        /// <summary>Initialises a new instance of the <see cref="LocationsViewModel"/> class.</summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="windowManager">The window manager.</param>
        [ImportingConstructor]
        public LocationsViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            if (Execute.InDesignMode)
            {
                this.LocationSelectorIsInFocus = true;
                this.Ids = new List<Guid> { Guid.NewGuid() };
            }

            this.LocationSelectorIsInFocus = true;

            this.locationRepository = new LocationRepositoryFactory(new DatabaseSeviceClient()).ForDefaultCulture();
            this.eventAggregator = eventAggregator;
            this.windowManager = windowManager;
        }

        /// <summary>Gets or sets the tab control visibility.</summary>
        public Visibility TabControlVisibility { get; set; }

        /// <summary>Gets or sets the location ids.</summary>
        public ICollection<Guid> Ids { get; set; }

        /// <summary>Gets or sets a value indicating whether location selector is in focus.</summary>
        public bool LocationSelectorIsInFocus { get; set; }

        /// <summary>Loads the location ids from the location repository.</summary>
        public void LoadIds()
        {
            this.Ids = this.locationRepository.Discover();
        }

        /// <summary>Toggles the visibility of the location list.</summary>
        public void ToggleLocationList()
        {
            this.LocationSelectorIsInFocus = !this.LocationSelectorIsInFocus;
        }

        /// <summary>Opens a location tab in the tab control.</summary>
        /// <param name="identifier">The location identifier.</param>
        public void OpenTab(Guid identifier)
        {
            // ToDo: Refine the activation process so we don't call the data source every time.
            // Maybe check the cached items for the requested GUID first, and then query the data source.
            var location = this.locationRepository.Find(identifier);

            if (this.Items.All(s => s.DisplayName != location.Name) && location != null)
            {
                // Make the tab control viosible to the user.
                this.TabControlVisibility = Visibility.Visible;

                // Create a new view model to show the data.
                LocationDetailViewModel locationDetail = new LocationDetailViewModel(this.eventAggregator, this.windowManager, this.locationRepository) { Location = location };

                // Activate the item.
                this.ActivateItem(locationDetail);

                this.LocationSelectorIsInFocus = false;
            }
        }

        /// <summary>Closes a tab from the location tab control.</summary>
        /// <param name="dataContext">The data context the tab belongs to.</param>
        public void CloseTab(object dataContext)
        {
            this.CloseItem(dataContext);

            if (!this.Items.Any())
            {
                this.TabControlVisibility = Visibility.Collapsed;
                this.LocationSelectorIsInFocus = true;
            }
        }
    }
}
