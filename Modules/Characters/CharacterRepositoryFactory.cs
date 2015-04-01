// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterRepositoryFactory.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Provides methods for creating the repository object in specified cultures.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Characters
{
    using System;
    using System.Globalization;

    using RpgTools.Core.Common;

    /// <summary>Provides methods for creating the repository object in specified cultures.</summary>
    public sealed class CharacterRepositoryFactory
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initialises a new instance of the <see cref="CharacterRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient">The service client to use.</param>
        public CharacterRepositoryFactory(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="language">The two-letter language code.</param>
        /// <returns>A repository.</returns>
        public ICharacterRepository this[string language]
        {
            get
            {
                return this.ForCulture(new CultureInfo(language));
            }
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public ICharacterRepository this[CultureInfo culture]
        {
            get
            {
                return this.ForCulture(culture);
            }
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public ICharacterRepository ForDefaultCulture()
        {
            return new CharactersRepository(this.serviceClient);
        }

        /// <summary>
        /// Creates an instance for the given language.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public ICharacterRepository ForCulture(CultureInfo culture)
        {
            throw new NotImplementedException("Multi Language Support has not yet been implemented. Use the \"ForDefaultCulture\" method instead.");
        }

        /// <summary>Creates an instance for the current system language.</summary>
        /// <returns>A repository.</returns>
        public ICharacterRepository ForCurrentCulture()
        {
            return this.ForCulture(CultureInfo.CurrentCulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <returns>A repository.</returns>
        public ICharacterRepository ForCurrentUiCulture()
        {
            return this.ForCulture(CultureInfo.CurrentUICulture);
        }
    }
}
