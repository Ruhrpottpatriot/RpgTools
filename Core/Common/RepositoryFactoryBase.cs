namespace RpgTools.Locations
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;

    /// <summary>Provides methods for creating repository objects.</summary>
    /// <typeparam name="TRepository">The type of repository to create.</typeparam>
    public abstract class RepositoryFactoryBase<TRepository>
    {
        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="language">The two-letter language code.</param>
        /// <returns>A repository.</returns>
        public TRepository this[string language]
        {
            get
            {
                Contract.Requires(language != null);
                Contract.Requires(language.Length == 2);
                Contract.Ensures(Contract.Result<TRepository>() != null);
                return this.ForCulture(new CultureInfo(language));
            }
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public TRepository this[CultureInfo culture]
        {
            get
            {
                Contract.Requires(culture != null);
                Contract.Ensures(Contract.Result<TRepository>() != null);
                return this.ForCulture(culture);
            }
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public abstract TRepository ForDefaultCulture();

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public abstract TRepository ForCulture(CultureInfo culture);

        /// <summary>Creates an instance for the current system language.</summary>
        /// <returns>A repository.</returns>
        public TRepository ForCurrentCulture()
        {
            Contract.Ensures(Contract.Result<TRepository>() != null);
            return this.ForCulture(CultureInfo.CurrentCulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <returns>A repository.</returns>
        public TRepository ForCurrentUiCulture()
        {
            Contract.Ensures(Contract.Result<TRepository>() != null);
            return this.ForCulture(CultureInfo.CurrentUICulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <returns>A repository.</returns>
        [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Consitent with the standard .NET naming.")]
        public virtual TRepository ForCurrentUICulture()
        {
            Contract.Ensures(Contract.Result<TRepository>() != null);
            return this.ForCulture(CultureInfo.CurrentUICulture);
        }
    }
}