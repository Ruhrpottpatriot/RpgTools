// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MefBootstrapper.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   The mef bootstrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows;

    using Caliburn.Micro;

    using RpgTools.Characters;
    using RpgTools.Core.Common;
    using RpgTools.Core.Contracts;
    using RpgTools.Tags;

    /// <summary>The MEF bootstrapper.</summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class MefBootstrapper : BootstrapperBase
    {
        /// <summary>Represents the path to the module directory relative to the executing assembly.</summary>
        private const string ModuleDirectory = "";

        /// <summary>The composition container.</summary>
        private CompositionContainer compositionContainer;

        /// <summary>Initialises a new instance of the <see cref="MefBootstrapper"/> class.</summary>
        public MefBootstrapper()
        {
            // this.CheckModuleDirectory();
            this.Initialize();
        }

        /// <summary>Override to configure the framework and setup your IoC container.</summary>
        protected override void Configure()
        {
            // Get the modules from the module directory
            // ToDo: Implement dynamic loading from modules directory.
            var assemblies = this.GetAssemblies().Select(fi => Assembly.LoadFrom(fi.FullName));

            // Add the assembliues to the assembly source.
            AssemblySource.Instance.AddRange(assemblies);

            // Add the assembly source to the catalog.
            var catalog = new AggregateCatalog(AssemblySource.Instance.Select(i => new AssemblyCatalog(i)).OfType<ComposablePartCatalog>());

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

            // ToDo: Use Application settinggs to allow the user to change the culture of the repository.
            compositionBatch.AddExportedValue(new TagsRepositoryFactory().ForDefaultCulture());
            compositionBatch.AddExportedValue(new CharacterRepositoryFactory().ForDefaultCulture());

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
        /// <param name="path">The path to check.</param>
        private void CheckDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>Gets the names and paths of all assemblies in the specified directory.
        /// </summary>
        /// <returns>
        /// An <see cref="FileInfo[]"/> containing the assemblies.</returns>
        private FileInfo[] GetAssemblies()
        {
            string pluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ModuleDirectory);

            this.CheckDirectory(pluginPath);

            return new DirectoryInfo(pluginPath).GetFiles("*.dll", SearchOption.AllDirectories);
        }
    }
}
