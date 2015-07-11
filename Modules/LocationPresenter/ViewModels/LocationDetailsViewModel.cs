// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationDetailsViewModel.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the LocationDetailViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.LocationPresenter.ViewModels
{
    using System;
    using System.Data.Entity.Spatial;
    using Caliburn.Micro;
    using PropertyChanged;
    using RpgTools.Core.Models;

    /// <summary>View model for displaying location details.</summary>
    [ImplementPropertyChanged]
    public class LocationDetailsViewModel : Screen
    {
        /// <summary>Initialises a new instance of the <see cref="LocationDetailsViewModel"/> class.</summary>
        public LocationDetailsViewModel()
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

        /// <summary>Gets or sets the location.</summary>
        public Location Location { get; set; }

        /// <summary>Gets or sets the windows name.</summary>
        public override string DisplayName
        {
            get
            {
                return this.Location.Name;
            }

            set
            {
                if (this.Location.Name == value)
                {
                    return;
                }

                this.Location.Name = value;
            }
        }

        /// <summary>Gets the type of the location.</summary>
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
}