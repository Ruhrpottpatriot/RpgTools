namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using System.Globalization;
    using System.Threading;
    using RpgTools.Characters.Migrations;
    using RpgTools.Core.Common;
    using RpgTools.Core.Common.Converter;
    using RpgTools.Core.Models;

    public sealed class CharactersRepository : DbContext, ICharacterRepository
    {
        private IConverter<IResponse<CharacterDataContract>, Character> responseConverter;

        private readonly IConverter<IResponse<ICollection<CharacterDataContract>>, IDictionaryRange<Guid, Character>> bulkResponseConverter;

        private readonly IConverter<Character, CharacterDataContract> writeConverter;

        public CharactersRepository()
            : this(new CharacterDataContractConverter(), new CharacterConverter())
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CharactersRepository, Configuration>(true));

            this.Characters = this.Set<CharacterDataContract>();
        }

        internal CharactersRepository(IConverter<CharacterDataContract, Character> characterDataContractConverter, IConverter<Character, CharacterDataContract> characterConverter)
            : base("name=RpgTools")
        {
            this.responseConverter = new ResponseConverter<CharacterDataContract, Character>(characterDataContractConverter);
            this.bulkResponseConverter = new DictionaryRangeConverter<CharacterDataContract, Guid, Character>(characterDataContractConverter, c => c.Id);
            this.writeConverter = characterConverter;
        }

        /// <summary>Gets or sets the locale.</summary>
        CultureInfo ILocalizable.Culture { get; set; }

        internal DbSet<CharacterDataContract> Characters { get; set; }

        /// <summary>Finds an object with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>An object of type <see cref="Character"/>.</returns>
        Character IRepository<Guid, Character>.Find(Guid identifier)
        {
            var data = new Response<CharacterDataContract>
            {
                Content = this.Characters.Include(c => c.Appearance).Include(c => c.Metadata).Single(c => c.Id == identifier),
                Culture = ((ILocalizable)this).Culture
            };
            return this.responseConverter.Convert(data);
        }

        /// <summary>Finds all objects with the given identifiers</summary>
        /// <param name="identifiers">The identifiers to look for.</param>
        /// <returns>A <see cref="IDictionaryRange{TKey, TValue}"/> with the objects.</returns>
        IDictionaryRange<Guid, Character> IRepository<Guid, Character>.FindAll(ICollection<Guid> identifiers)
        {
            var data = new Response<ICollection<CharacterDataContract>>
                       {
                           Content = this.Characters.Include(c => c.Appearance).Include(c => c.Metadata).Where(c => identifiers.Any(i => i == c.Id)).ToList(),
                           Culture = ((ILocalizable)this).Culture
                       };
            return this.bulkResponseConverter.Convert(data);
        }

        /// <summary>Finds all objects.</summary>
        /// <returns>A <see cref="IDictionaryRange{TKey, TValue}"/> with the objects.</returns>
        IDictionaryRange<Guid, Character> IRepository<Guid, Character>.FindAll()
        {
            var data = new Response<ICollection<CharacterDataContract>>
            {
                Content = this.Characters.Include(c => c.Appearance).Include(c => c.Metadata).ToList(),
                Culture = ((ILocalizable)this).Culture
            };
            return this.bulkResponseConverter.Convert(data);
        }

        Task<IDictionaryRange<Guid, Character>> IRepository<Guid, Character>.FindAllAsync()
        {
            return ((ICharacterRepository)this).FindAllAsync(CancellationToken.None);
        }

        async Task<IDictionaryRange<Guid, Character>> IRepository<Guid, Character>.FindAllAsync(CancellationToken cancellationToken)
        {
            var data = new Response<ICollection<CharacterDataContract>>
                       {
                           Content = await this.Characters.Include(c => c.Appearance).Include(c => c.Metadata).ToListAsync(cancellationToken),
                           Culture = ((ILocalizable)this).Culture

                       };
            return this.bulkResponseConverter.Convert(data);
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        ///             before the model has been locked down and used to initialize the context.  The default
        ///             implementation of this method does nothing, but it can be overridden in a derived class
        ///             such that the model can be further configured before it is locked down.
        /// </summary>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        ///             is created.  The model for that context is then cached and is for all further instances of
        ///             the context in the app domain.  This caching can be disabled by setting the ModelCaching
        ///             property on the given ModelBuidler, but note that this can seriously degrade performance.
        ///             More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        ///             classes directly.
        /// </remarks>
        /// <param name="modelBuilder">The builder that defines the model for the context being created. </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Characters");
        }
    }

    internal sealed class CharacterConverter : IConverter<Character, CharacterDataContract>
    {
        /// <summary>Converts the given object of type <typeparamref name="TInput"/> to an object of type <typeparamref name="TOutput"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public CharacterDataContract Convert(Character value)
        {
            throw new NotImplementedException();
        }
    }
}
