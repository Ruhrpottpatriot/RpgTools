// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagsRepositoryFactory.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Provides methods and properties to create <see cref="TagsRepository" /> objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Tags
{
    using System.Globalization;
    using RpgTools.Core.Common;
    using RpgTools.Locations;

    /// <summary>Provides methods and properties to create <see cref="TagsRepository"/> objects.</summary>
    public sealed class TagsRepositoryFactory : RepositoryFactoryBase<ITagsRepository>
    {
        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override ITagsRepository ForDefaultCulture()
        {
            ITagsRepository repository = new TagsRepository();
            repository.Culture = new CultureInfo("en");
            return repository;
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override ITagsRepository ForCulture(CultureInfo culture)
        {
            ITagsRepository repository = new TagsRepository();
            repository.Culture = culture;
            return repository;
        }
    }
}
