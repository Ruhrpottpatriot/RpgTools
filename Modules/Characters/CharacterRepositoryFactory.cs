// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterRepositoryFactory.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Provides methods an properties to create a <see cref="CharacterRepository" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System.Globalization;

    using RpgTools.Core.Common;

    /// <summary>Provides methods an properties to create a <see cref="CharacterRepository"/>.</summary>
    public sealed class CharacterRepositoryFactory : RepositoryFactoryBase<ICharacterRepository>
    {
        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override ICharacterRepository ForDefaultCulture()
        {
            ICharacterRepository repository = new CharacterRepository(new CharacterReadConverter(), new CharacterWriteConverter());
            repository.Culture = new CultureInfo("en");
            return repository;
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override ICharacterRepository ForCulture(CultureInfo culture)
        {
            ICharacterRepository repository = new CharacterRepository(new CharacterReadConverter(), new CharacterWriteConverter());
            repository.Culture = culture;
            return repository;
        }
    }
}
