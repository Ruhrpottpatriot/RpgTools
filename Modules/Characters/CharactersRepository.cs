// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharactersRepository.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the CharactersRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using RpgTools.Characters.Migrations;
    using RpgTools.Core.Common;
    using RpgTools.Core.Common.Converter;
    using RpgTools.Core.Models;

    /// <summary>Repository for storing and retrieving characters in a database.</summary>
    public sealed class CharactersRepository : DbContext, ICharacterRepository
    {
        /// <summary>Infrastructure. Holds a reference to the response converter.</summary>
        private readonly IConverter<IResponse<CharacterDataContract>, Character> responseConverter;

        /// <summary>Infrastructure. Holds a reference to the bulk identifiers converter.</summary>
        private readonly IConverter<IResponse<ICollection<CharacterDataContract>>, IDictionaryRange<Guid, Character>> bulkResponseConverter;

        /// <summary>Infrastructure. Holds a reference to the write converter.</summary>
        private readonly IConverter<Character, CharacterDataContract> writeConverter;

        /// <summary>Initialises a new instance of the <see cref="CharactersRepository"/> class.</summary>
        public CharactersRepository()
            : this(new CharacterDataContractConverter(), new CharacterConverter())
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CharactersRepository, Configuration>(true));

            this.Characters = this.Set<CharacterDataContract>();
        }

        /// <summary>Initialises a new instance of the <see cref="CharactersRepository"/> class.</summary>
        /// <param name="characterDataContractConverter">The character data contract converter.</param>
        /// <param name="characterConverter">The character converter.</param>
        internal CharactersRepository(IConverter<CharacterDataContract, Character> characterDataContractConverter, IConverter<Character, CharacterDataContract> characterConverter)
            : base("name=RpgTools")
        {
            this.responseConverter = new ResponseConverter<CharacterDataContract, Character>(characterDataContractConverter);
            this.bulkResponseConverter = new DictionaryRangeConverter<CharacterDataContract, Guid, Character>(characterDataContractConverter, c => c.Id);
            this.writeConverter = characterConverter;
        }

        /// <summary>Gets or sets the locale.</summary>
        CultureInfo ILocalizable.Culture { get; set; }

        /// <summary>Gets or sets the internal character list.</summary>
        internal DbSet<CharacterDataContract> Characters { get; set; }

        /// <inheritdoc />
        Character IRepository<Guid, Character>.Find(Guid identifier)
        {
            var data = new Response<CharacterDataContract>
            {
                Content = this.Characters.Include(c => c.Appearance).Include(c => c.Metadata).Single(c => c.Id == identifier),
                Culture = ((ILocalizable)this).Culture
            };
            return this.responseConverter.Convert(data);
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Character> IRepository<Guid, Character>.FindAll(ICollection<Guid> identifiers)
        {
            var data = new Response<ICollection<CharacterDataContract>>
                       {
                           Content = this.Characters.Include(c => c.Appearance).Include(c => c.Metadata).Where(c => identifiers.Any(i => i == c.Id)).ToList(),
                           Culture = ((ILocalizable)this).Culture
                       };
            return this.bulkResponseConverter.Convert(data);
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Character> IRepository<Guid, Character>.FindAll()
        {
            var data = new Response<ICollection<CharacterDataContract>>
            {
                Content = this.Characters.Include(c => c.Appearance).Include(c => c.Metadata).ToList(),
                Culture = ((ILocalizable)this).Culture
            };
            return this.bulkResponseConverter.Convert(data);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<Guid, Character>> IRepository<Guid, Character>.FindAllAsync()
        {
            return ((ICharacterRepository)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<Guid, Character>> IRepository<Guid, Character>.FindAllAsync(CancellationToken cancellationToken)
        {
            var data = new Response<ICollection<CharacterDataContract>>
                       {
                           Content = await this.Characters.Include(c => c.Appearance).Include(c => c.Metadata).ToListAsync(cancellationToken),
                           Culture = ((ILocalizable)this).Culture
                       };

            return this.bulkResponseConverter.Convert(data);
        }

        /// <inheritdoc />
        void IWriteable<Character>.Write(Character data)
        {
            CharacterDataContract dataContract = this.writeConverter.Convert(data);

            this.Characters.AddOrUpdate(c => c.Id, dataContract);
            this.SaveChanges();
        }

        /// <inheritdoc />
        void IWriteable<Character>.WriteAsync(Character data)
        {
            ((ICharacterRepository)this).WriteAsync(data, CancellationToken.None);
        }

        /// <inheritdoc />
        void IWriteable<Character>.WriteAsync(Character data, CancellationToken cancellationToken)
        {
            CharacterDataContract dataContract = this.writeConverter.Convert(data);

            this.Characters.AddOrUpdate(c => c.Id, dataContract);
            this.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc />
        void IWriteable<Character>.Delete(Character data)
        {
            CharacterDataContract dataContract = this.writeConverter.Convert(data);

            this.Characters.Remove(dataContract);
            this.SaveChanges();
        }

        /// <inheritdoc />
        void IWriteable<Character>.DeleteAsync(Character data)
        {
            ((ICharacterRepository)this).DeleteAsync(data, CancellationToken.None);
        }

        /// <inheritdoc />
        void IWriteable<Character>.DeleteAsync(Character data, CancellationToken cancellationToken)
        {
            CharacterDataContract dataContract = this.writeConverter.Convert(data);

            this.Characters.Remove(dataContract);
            this.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Characters");
        }
    }
}
