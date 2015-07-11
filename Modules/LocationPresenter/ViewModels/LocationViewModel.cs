// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationViewModel.cs" company="Robert Logiewa">
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
    using System.Collections.ObjectModel;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Windows;
    using Caliburn.Micro;
    using PropertyChanged;
    using RpgTools.Core;
    using RpgTools.Core.Common;
    using RpgTools.Core.Contracts;
    using RpgTools.Core.Models;
    using RpgTools.Locations;

    /// <summary>Represents the location view model.</summary>
    [ImplementPropertyChanged]
    [RpgModuleMetadata(Name = "Locations")]
    [Export(typeof(IRpgModuleContract))]
    public class LocationViewModel : Conductor<LocationDetailsViewModel>.Collection.OneActive, IRpgModuleContract
    {
        /// <summary>Infrastructure. Holds a reference to the  location repository.</summary>
        private readonly ILocationRepository locationRepository;

        /// <summary>Infrastructure. Holds a reference to the  window manager.</summary>
        private readonly IWindowManager windowManager;

        /// <summary>Infrastructure. Holds a reference to the event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>Initialises a new instance of the <see cref="LocationViewModel"/> class.</summary>
        public LocationViewModel()
        {
            if (Execute.InDesignMode)
            {
                this.LocationSelectorVisible = true;
                this.SaveButtonVisible = true;
                this.TabControlVisible = true;

                this.CheckListItems = new ObservableCollection<CheckListItem>
                                      {
                                          new CheckListItem("All", true),
                                          new CheckListItem("Location", false)
                                      };
                var guids = new[] { Guid.NewGuid(), Guid.NewGuid() };

                this.Locations = new DictionaryRange<Guid, Location>
                                 {
                                     {
                                         guids[0],
                                         new City
                                         {
                                             Id = guids[0],
                                             Name = "Stromsang",
                                             Description = "A City"
                                         }
                                     },
                                     {
                                         guids[1],
                                         new Location
                                         {
                                             Id = guids[1],
                                             Name = "Forst",
                                             Description = "A place with trees"
                                         }
                                     }
                                 };
            }
        }

        /// <summary>Initialises a new instance of the <see cref="LocationViewModel"/> class.</summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="windowManager">The window manager.</param>
        [ImportingConstructor]
        public LocationViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            this.locationRepository = new LocationRepositoryFactory().ForDefaultCulture();
            this.eventAggregator = eventAggregator;
            this.windowManager = windowManager;

            // Set the initial visibilities of controls.
            this.LocationSelectorVisible = true;
            this.SaveButtonVisible = false;
            this.TabControlVisible = false;

            // Generate the check list items
            this.CheckListItems = new ObservableCollection<CheckListItem>();
            this.CheckListItems.Insert(0, new CheckListItem(Constants.AllOptions, true));
        }

        /// <summary>Gets or sets a value indicating whether the location selector is visible.</summary>
        public bool LocationSelectorVisible { get; set; }

        /// <summary>Gets or sets a value indicating whether the save button is visible.</summary>
        public bool SaveButtonVisible { get; set; }

        /// <summary>Gets or sets a value indicating whether the tab control is visible.</summary>
        public bool TabControlVisible { get; set; }

        /// <summary>Gets or sets the locations.</summary>
        public IDictionaryRange<Guid, Location> Locations { get; set; }

        /// <summary>Gets or sets the list of check list items.</summary>
        public ObservableCollection<CheckListItem> CheckListItems { get; set; }

        /// <summary>Toggles the visibility of the location list.</summary>
        public void ToggleLocationList()
        {
            this.LocationSelectorVisible = !this.LocationSelectorVisible;
        }

        /// <summary>Opens a location tab in the tab control.</summary>
        /// <param name="location">The location.</param>
        public void OpenLocationTab(KeyValuePair<Guid, Location> location)
        {
            if (this.Items.All(s => s.DisplayName != location.Value.Name) && location.Value != null)
            {
                // Make the tab control viosible to the user.
                this.TabControlVisible = true;

                this.ActivateItem(new LocationDetailsViewModel
                {
                    Location = location.Value
                });

                this.LocationSelectorVisible = false;
                this.SaveButtonVisible = true;
            }
        }

        /// <summary>Closes a tab from the location tab control.</summary>
        /// <param name="detailsViewModel">The data context the tab belongs to.</param>
        public void CloseTab(LocationDetailsViewModel detailsViewModel)
        {
            this.CloseItem(detailsViewModel);

            if (!this.Items.Any())
            {
                this.TabControlVisible = false;
                this.LocationSelectorVisible = true;
                this.SaveButtonVisible = false;
            }
        }

        /// <summary>Closes all location tabs.</summary>
        /// <param name="locations">The locations to close.</param>
        public void CloseTabs(ICollection<LocationDetailsViewModel> locations)
        {
            foreach (LocationDetailsViewModel viewModel in locations)
            {
                this.CloseTab(viewModel);
            }
        }

        /// <summary>Closes a collection of tabs, except one.</summary>
        /// <param name="locations">The locations to close.</param>
        /// <param name="location">The location to except from closing.</param>
        public void CloseTabsExcept(ICollection<LocationDetailsViewModel> locations, LocationDetailsViewModel location)
        {
            foreach (LocationDetailsViewModel viewModel in locations.Where(vm => vm.DisplayName != location.DisplayName))
            {
                this.CloseTab(viewModel);
            }
        }

        /// <summary>Loads the location ids from the location repository.</summary>
        public void LoadLocations()
        {
            this.Locations = this.locationRepository.FindAll();
        }

        /// <summary>Loads the locations types and updates the filter list.</summary>
        public void LoadLocationTypes()
        {
            IEnumerable<string> types = this.Locations.Values.Select(l => l.GetType().Name);

            types.Where(t => this.CheckListItems.All(i => i.Name != t)).ToList().ForEach(t => this.CheckListItems.Add(new CheckListItem(t, true)));
        }

        /// <summary>Filters the locations based on the checked check boxes.</summary>
        public void FilterLocations()
        {
            // Check if the locations have been loaded.
            // if not just return.
            if (this.Locations == null)
            {
                return;
            }

            // If the all item is checked, we can safely return all locations without filtering.
            if (this.CheckListItems.Any(i => (i.Name == Constants.AllOptions && (i.IsChecked != null && (bool)i.IsChecked))))
            {
                this.Locations = this.locationRepository.FindAll();
                return;
            }

            // Get the checked items.
            var checkedBoxes = this.CheckListItems.Where(i => (i.IsChecked != null && (bool)i.IsChecked));

            this.Locations = new DictionaryRange<Guid, Location>(this.locationRepository.FindAll().Where(l => checkedBoxes.Any(b => b.Name == l.Value.GetType().Name)).ToDictionary(x => x.Key, x => x.Value));
        }

        /// <summary>Toggles check list item.</summary>
        /// <param name="sender">The item that changed.</param>
        /// <param name="isChecked">The state of the item.
        /// </param>
        public void FilterChecklist(string sender, bool isChecked)
        {
            // Check if the locations have been loaded.
            // if not just return.
            if (this.Locations == null)
            {
                return;
            }

            // Check if the sender was the "all" item.
            if (sender == Constants.AllOptions)
            {
                // Set all items to be set if "all" was checked.
                // Otherwise set all items to be unchecked.
                if (isChecked)
                {
                    foreach (CheckListItem item in this.CheckListItems)
                    {
                        item.IsChecked = true;
                    }
                }
                else
                {
                    foreach (CheckListItem item in this.CheckListItems)
                    {
                        item.IsChecked = false;
                    }
                }
            }
            else
            {
                // Since we didn't change the all item 
                // we have to check if all others are checked
                // to determine the correct state of the all item.
                var allItem = this.CheckListItems.Single(i => i.Name == Constants.AllOptions);

                var itemsWithoutAll = new List<CheckListItem>(this.CheckListItems.Where(i => i != allItem));

                if (itemsWithoutAll.All(i => i.IsChecked != null && (bool)i.IsChecked))
                {
                    allItem.IsChecked = true;
                }
                else if (itemsWithoutAll.Any(i => i.IsChecked != null && (bool)i.IsChecked))
                {
                    allItem.IsChecked = null;
                }
                else
                {
                    allItem.IsChecked = false;
                }
            }
        }

        /// <summary>Saves a location to the repository.</summary>
        /// <param name="viewModel">The view model with the location to be saved.</param>
        public void SaveLocation(LocationDetailsViewModel viewModel)
        {
            // Get the location to save
            Location location = viewModel.Location;

            // Save the location to the repository
            this.locationRepository.Update(new DataContainer<Location> { Content = location });

            // Reload the screen.
            this.CloseTab(viewModel);
            this.OpenLocationTab(new KeyValuePair<Guid, Location>(location.Id, location));
        }

        /// <summary>Saves all currently opened locations to the repository.</summary>
        /// <param name="locationDetails">The location detail view models.</param>
        public void SaveAllLocations(ICollection<LocationDetailsViewModel> locationDetails)
        {
            foreach (LocationDetailsViewModel viewModel in locationDetails)
            {
                this.SaveLocation(viewModel);
            }
        }

        /// <summary>Deletes a location from the repository.</summary>
        /// <param name="viewModel">The location to be deleted.</param>
        public void DeleteLocation(object viewModel)
        {
            // Get the location to save
            Guid locationId = ((LocationDetailsViewModel)viewModel).Location.Id;

            this.locationRepository.Delete(locationId);
            this.Locations.Remove(locationId);
        }

        /// <summary>Creates a new location from scratch.</summary>
        public void CreateLocation()
        {
            NewLocationViewModel newLocation = new NewLocationViewModel { DisplayName = "Create Location" };

            Dictionary<string, object> settingsDictionary = new Dictionary<string, object>
            {
                { "ResizeMode", ResizeMode.NoResize } 
            };

            bool? answer = this.windowManager.ShowDialog(newLocation, null, settingsDictionary);

            if (answer.HasValue && answer.Value)
            {
                this.locationRepository.Create(new DataContainer<Location> { Content = newLocation.Location });
            }

            this.FilterLocations();
        }
    }
}
