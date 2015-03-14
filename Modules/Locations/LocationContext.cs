// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationContext.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Describes the location context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations
{
    using System.Data.Entity;

    using RpgTools.Locations.DataContracts;

    /// <summary>Describes the location context.</summary>
    public sealed class LocationContext : DbContext
    {
        /// <summary>Initialises a new instance of the <see cref="LocationContext"/> class.</summary>
        public LocationContext()
            : base("name=RpgTools")
        {
            // Set the initializer. ToDo: Needs to be changed for production enviroment.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LocationContext, Migrations.Configuration>(true));

            this.Locations = this.Set<LocationDataContract>();
        }

        /// <summary>Gets or sets the locations data set.</summary>
        internal DbSet<LocationDataContract> Locations { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuilder, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        /// <param name="modelBuilder">The builder that defines the model for the context being created. </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Locations");

            modelBuilder.Entity<CityDetailsDataContract>().Map(
                m =>
                    {
                        m.MapInheritedProperties();
                    });

            modelBuilder.Entity<PlanetDetailsDataContract>().Map(
                m =>
                    {
                        m.MapInheritedProperties();
                    });

            modelBuilder.Entity<StarSystemDetailsDataContract>().Map(
                m =>
                    {
                        m.MapInheritedProperties();
                    });

            modelBuilder.Entity<SectorDetailsDataContract>().Map(
                m =>
                    {
                        m.MapInheritedProperties();
                    });
        }
    }
}