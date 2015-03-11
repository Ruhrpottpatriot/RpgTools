using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTools.ViewModels
{
    using System.ComponentModel.Composition;

    using Caliburn.Micro; 

    using RpgTools.Core.Contracts;

    [RpgModuleMetadata(Name = "Module A")]
    [Export(typeof(IRpgModuleContract))]
    public class LocationsViewModel : IRpgModuleContract
    {
        public LocationsViewModel()
        {
            if (Execute.InDesignMode)
            {
                this.Text = "Test";
            }
        }

        public string Text { get; set; }
    }
}
