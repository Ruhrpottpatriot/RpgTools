// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MefBootstrapper.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   The mef bootstrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Windows;

    using Caliburn.Micro;

    using RpgTools.Core.Contracts;

    /// <summary>The MEF bootstrapper.</summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class MefBootstrapper : BootstrapperBase
    {
        /// <summary>The composition container.</summary>
        private CompositionContainer compositionContainer;

        /// <summary>Initialises a new instance of the <see cref="MefBootstrapper"/> class.</summary>
        public MefBootstrapper()
        {
            this.CheckModuleDirectory();

            this.Initialize();
        }

        /// <summary>Override to configure the framework and setup your IoC container.</summary>
        protected override void Configure()
        {
            // Get the modules from the module directory
            DirectoryCatalog dirCatalog = new DirectoryCatalog(@".\Modules");

            // Create a combinable catalog
            // ReSharper disable once RedundantEnumerableCastCall
            AggregateCatalog catalog = new AggregateCatalog(AssemblySource.Instance.Select(s => new AssemblyCatalog(s)).OfType<ComposablePartCatalog>());
            catalog.Catalogs.Add(dirCatalog);

            // Create a new composition container.
            // ReSharper disable once RedundantEnumerableCastCall
            this.compositionContainer = new CompositionContainer();

            // Create a new composition container.
            this.compositionContainer = new CompositionContainer(catalog);

            CompositionBatch compositionBatch = new CompositionBatch();

            // Add window manager to composition batch.
            compositionBatch.AddExportedValue<IWindowManager>(new ToolsWindowManager());

            // Add EventAggregator to composition batch.
            compositionBatch.AddExportedValue<IEventAggregator>(new EventAggregator());

            // Add the container itself.
            compositionBatch.AddExportedValue(this.compositionContainer);

            // Compose the container.
            this.compositionContainer.Compose(compositionBatch);
        }

        /// <summary>Override this to provide an IoC specific implementation.</summary>
        /// <param name="service">The service to locate.</param>
        /// <param name="key">The key to locate.</param>
        /// <returns>The located service.</returns>
        protected override object GetInstance(Type service, string key)
        {
            // Check if the contract is null or an empty string, if so return the contract name from the service itself.
            string contractName = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(service) : key;

            // Get a collection of exported values with the goven contract name. 
            IList<object> exports = this.compositionContainer.GetExportedValues<object>(contractName).ToList();

            if (exports.Any())
            {
                return exports.First();
            }

            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contractName));
        }

        /// <summary>Override this to provide an IoC specific implementation</summary>
        /// <param name="serviceType">The service to locate.</param> 
        /// <returns>The located services.</returns>
        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return this.compositionContainer.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        /// <summary>Override this to provide an IoC specific implementation.</summary>
        /// <param name="instance"> The instance to perform injection on.</param>
        protected override void BuildUp(object instance)
        {
            this.compositionContainer.SatisfyImportsOnce(instance);
        }

        /// <summary>Override this to add custom behaviour to execute after the application starts.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The args.</param>
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            this.DisplayRootViewFor<IShell>();
        }

        /// <summary>Checks if the modules directory exists and if not create it.</summary>
        private void CheckModuleDirectory()
        {
            if (!Directory.Exists(@".\Modules"))
            {
                Directory.CreateDirectory(@".\Modules");
            }
        }
    }
}
