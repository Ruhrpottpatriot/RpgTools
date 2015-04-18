namespace RpgTools.Tags
{
    using System.Globalization;
    using RpgTools.Characters;
    using RpgTools.Core.Common;
    using RpgTools.Locations;

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
