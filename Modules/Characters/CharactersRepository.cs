// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharactersRepository.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the CharactersRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Characters
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Characters.Converters;
    using Characters.DataContracts;

    using RpgTools.Core.Common;
    using RpgTools.Core.Models.Characters;
    using RpgTools.Locations.Converter;

    /// <summary>The characters repository.</summary>
    public sealed class CharactersRepository : DbContext, ICharacterRepository
    {
        /// <summary>Infrastructure. Holds a reference to the response converter.</summary>
        private readonly IConverter<IResponse<CharacterDataContract>, Character> characterResponseConverter;

        /// <summary>Infrastructure. Holds a reference to the write converter.</summary>
        private readonly IConverter<Character, CharacterDataContract> writeConverter;

        /// <summary>Infrastructure. Holds a reference to the bulk response converter.</summary>
        private readonly IConverter<IResponse<ICollection<CharacterDataContract>>, IDictionaryRange<Guid, Character>> bulkResponseConverter;

        /// <summary>Initialises a new instance of the <see cref="CharactersRepository"/> class.</summary>
        public CharactersRepository()
            : this(new CharacterConverter(), new CharacterDataContractConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="CharactersRepository"/> class.</summary>
        /// <param name="characterResponseConverter">The character response converter.</param>
        /// <param name="writeConverter">The write converter.</param>
        internal CharactersRepository(IConverter<CharacterDataContract, Character> characterResponseConverter, IConverter<Character, CharacterDataContract> writeConverter)
            : base("name=RpgTools")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CharactersRepository, Migrations.Configuration>(true));

            this.CharactersDbSet = this.Set<CharacterDataContract>();

            this.characterResponseConverter = new ResponseConverter<CharacterDataContract, Character>(characterResponseConverter);
            this.bulkResponseConverter = new DictionaryRangeConverter<CharacterDataContract, Guid, Character>(characterResponseConverter, c => c.Metadata.Id);

            this.writeConverter = writeConverter;
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <summary>Gets or sets the characters db set.</summary>
        internal DbSet<CharacterDataContract> CharactersDbSet { get; set; }

        /// <inheritdoc />
        ICollection<Guid> IDiscoverable<Guid>.Discover()
        {
            return this.CharactersDbSet.Select(i => i.Id).ToList();
        }

        /// <inheritdoc />
        Task<ICollection<Guid>> IDiscoverable<Guid>.DiscoverAsync()
        {
            ICharacterRepository self = this;
            return self.DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<Guid>> IDiscoverable<Guid>.DiscoverAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        Character IRepository<Guid, Character>.Find(Guid identifier)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Character> IRepository<Guid, Character>.FindAll(ICollection<Guid> identifiers)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Character> IRepository<Guid, Character>.FindAll()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        void IWriteable<Character>.Write(Character data)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        void IWriteable<Character>.WriteAsync(Character data)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        void IWriteable<Character>.WriteAsync(Character data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Characters");
        }
    }
}
