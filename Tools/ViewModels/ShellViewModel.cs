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
        /// <summary>Initialises a new instance of the <see cref="ShellViewModel"/> class.</summary>
        public ShellViewModel()
        {
            if (Execute.InDesignMode)
            {
            }
        }

        /// <summary>Gets or sets a collection of modules.</summary>
        [ImportMany(typeof(IRpgModuleContract))]
        public IEnumerable<Lazy<IRpgModuleContract, IRpgModuleMetadata>> RpgModules { get; set; }

        /// <summary>Gets or sets a value indicating whether a module is selected.</summary>
        public bool IsModuleSelected { get; set; }

        /// <summary>Gets or sets the current module.</summary>
        public IRpgModuleContract CurrentModule { get; set; }

        /// <summary>Selects a model and displays it on the screen.</summary>
        /// <param name="name">The name of the module.</param>
        public void SelectModule(string name)
        {
            this.CurrentModule = this.RpgModules.Single(m => m.Metadata.Name == name).Value;
            this.IsModuleSelected = true;
        }

        /// <summary>Hides the current module and returns back to the module selector.</summary>
        public void BackToMain()
        {
            this.CurrentModule = null;
            this.IsModuleSelected = false;
        }
    }
}
