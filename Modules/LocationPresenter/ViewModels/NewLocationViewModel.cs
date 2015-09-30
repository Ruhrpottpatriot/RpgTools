// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewLocationViewModel.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the NewLocationViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.LocationPresenter.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Caliburn.Micro;
    using PropertyChanged;
    using RpgTools.Core.Models;

    /// <summary>The new location view model.</summary>
    [ImplementPropertyChanged]
    public class NewLocationViewModel : Screen
    {
        /// <summary>Stores the location as a collection of strings.</summary>
        private List<string> tags;

        /// <summary>Initializes a new instance of the <see cref="NewLocationViewModel"/> class.</summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "Reviewed")]
        public NewLocationViewModel()
        {
            if (Execute.InDesignMode)
            {
                this.Id = Guid.NewGuid();
                this.Type = LocationType.City;
                this.Name = "Stromsang";
                this.Description = "Sample Desacription";
            }

            this.tags = new List<string>();
            this.Id = Guid.NewGuid();
        }

        /// <summary>Gets or sets the id.</summary>
        public Guid Id { get; set; }

        /// <summary>Gets a value indicating whether a location can be created.</summary>
        public bool CanCreate
        {
            get
            {
                return !string.IsNullOrEmpty(this.Name) && !string.IsNullOrWhiteSpace(this.Name);
            }
        }

        /// <summary>Gets or sets the name.</summary>
        [AlsoNotifyFor("CanCreate")]
        public string Name { get; set; }

        /// <summary>Gets or sets the type.</summary>
        public LocationType Type { get; set; }

        /// <summary>Gets or sets the description.</summary>
        public string Description { get; set; }

        /// <summary> Gets or sets the tags as a semicolon separated string.</summary>
        public string Tags
        {
            get
            {
                return string.Join("; ", this.tags);
            }

            set
            {
                char[] delimiters = { ',', ';', ' ' };

                List<string> tags = value.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();

                this.tags = tags;
            }
        }

        /// <summary>Gets the location to return.</summary>
        public Location Location { get; private set; }

        /// <summary>Creates a new location and returns it to the creating view model.</summary>
        public void Create()
        {
            Location location;
            switch (this.Type)
            {
                case LocationType.City:
                    location = new City();
                    break;
                case LocationType.Planet:
                    location = new Planet();
                    break;
                case LocationType.Sector:
                    location = new Sector();
                    break;
                case LocationType.StarSystem:
                    location = new StarSystem();
                    break;
                default:
                    location = new Location();
                    break;
            }

            location.Id = Guid.NewGuid();
            location.Name = this.Name;
            location.Tags = this.tags;

            this.Location = location;

            this.TryClose(true);
        }

        /// <summary>Cancels the creation and closes the window.</summary>
        public void Cancel()
        {
            this.TryClose(false);
        }
    }
}
