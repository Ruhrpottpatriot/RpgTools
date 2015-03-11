namespace RpgTools.Main.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    using Caliburn.Micro;

    using PropertyChanged;

    using RpgTools.Core.Common;
    using RpgTools.Core.Contracts;
    using RpgTools.Locations;

    [ImplementPropertyChanged]
    [RpgModuleMetadata(Name = "Locations")]
    [Export(typeof(IRpgModuleContract))]
    public class LocationsViewModel : IRpgModuleContract
    {
        private ILocationRepository locationRepository;

        public LocationsViewModel()
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

        public ICollection<Guid> Ids { get; set; }
    }
}
