// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShellViewModel.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the ShellViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel.Composition;


    using PropertyChanged;

    using RpgTools.Core.Contracts;

    [ImplementPropertyChanged]
    [Export(typeof(IShell))]
    public class ShellViewModel : IShell
    {
        [ImportMany(typeof(IRpgModuleContract))]
        public IEnumerable<Lazy<IRpgModuleContract, IRpgModuleMetadata>> RpgModules { get; set; }

        public ShellViewModel()
        {
        }

        public IRpgModuleContract CurrentModule
        {
            get;
            set;
        }

        public void SelectModule(string name)
        {
            this.CurrentModule = this.RpgModules.Single(m => m.Metadata.Name == name).Value;
        }
    }
}
