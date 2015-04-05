// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShellViewModel.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the ShellViewModel.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Main.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using Caliburn.Micro;
    using PropertyChanged;

    using RpgTools.Core.Contracts;

    /// <summary>Defines the ShellViewModel.</summary>
    [ImplementPropertyChanged]
    [Export(typeof(IShell))]
    public class ShellViewModel : IShell
    {
        [ImportMany(typeof(IRpgModuleContract))]
        public IEnumerable<Lazy<IRpgModuleContract, IRpgModuleMetadata>> RpgModules { get; set; }

        public ShellViewModel()
        {
            if (Execute.InDesignMode)
            {
            }
        }

        public bool IsModuleSelected { get; set; }

        public IRpgModuleContract CurrentModule { get; set; }

        public void SelectModule(string name)
        {
            this.CurrentModule = this.RpgModules.Single(m => m.Metadata.Name == name).Value;
            this.IsModuleSelected = true;
        }

        public void BackToMain()
        {
            this.CurrentModule = null;
            this.IsModuleSelected = false;
        }
    }
}
