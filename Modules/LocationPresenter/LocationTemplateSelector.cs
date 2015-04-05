// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationTemplateSelector.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.LocationPresenter
{
    using System.Windows;
    using System.Windows.Controls;
    using RpgTools.Core.Models;

    /// <summary>
    /// The location template selector.
    /// </summary>
    public class LocationTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets the location template.
        /// </summary>
        public DataTemplate LocationTemplate { get; set; }

        /// <summary>
        /// Gets or sets the star system template.
        /// </summary>
        public DataTemplate StarSystemTemplate { get; set; }

        /// <summary>
        /// Gets or sets the sector template.
        /// </summary>
        public DataTemplate SectorTemplate { get; set; }

        /// <summary>
        /// Gets or sets the planet template.
        /// </summary>
        public DataTemplate PlanetTemplate { get; set; }

        /// <summary>
        /// Gets or sets the city template.
        /// </summary>
        public DataTemplate CityTemplate { get; set; }
        
        /// <summary>
        /// When overridden in a derived class, returns a <see cref="T:System.Windows.DataTemplate"/> based on custom logic.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="T:System.Windows.DataTemplate"/> or null. The default value is null.
        /// </returns>
        /// <param name="item">
        /// The data object for which to select the template.
        /// </param>
        /// <param name="container">
        /// The data-bound object.
        /// </param>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
            {
                return null;
            }

            if (item is StarSystem)
            {
                return this.StarSystemTemplate;
            }

            if (item is Sector)
            {
                return this.SectorTemplate;
            }

            if (item is Planet)
            {
                return this.PlanetTemplate;
            }

            if (item is City)
            {
                return this.CityTemplate;
            }

            return this.LocationTemplate;
        }
    }
}
