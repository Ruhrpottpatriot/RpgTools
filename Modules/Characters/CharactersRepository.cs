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
        private readonly IConverter<IResponse<CharacterDataContract>, Character> responseConverter;

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

            this.Count = this.CharactersDbSet.Count();

            this.responseConverter = new ResponseConverter<CharacterDataContract, Character>(characterResponseConverter);
            this.bulkResponseConverter = new DictionaryRangeConverter<CharacterDataContract, Guid, Character>(characterResponseConverter, c => c.Metadata.Id);

            this.writeConverter = writeConverter;
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <summary>Gets or sets the characters db set.</summary>
        internal DbSet<CharacterDataContract> CharactersDbSet { get; set; }

        /// <summary>Gets or sets the number of items in the DbSet.</summary>
        internal int Count { get; set; }

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
            throw new NotSupportedException("This operation is currently not supported.");
        }

        /// <inheritdoc />
        Character IRepository<Guid, Character>.Find(Guid identifier)
        {
            var character = this.CharactersDbSet.SingleOrDefault(c => c.Id == identifier);

            if (character == null)
            {
                return null;
            }

            this.GetCharacterDetails(character);

            var response = this.CreateResponse(character);

            return this.responseConverter.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Character> IRepository<Guid, Character>.FindAll(ICollection<Guid> identifiers)
        {
            ICollection<CharacterDataContract> characters = this.CharactersDbSet.Where(c => identifiers.Any(i => i == c.Id)).ToList();

            foreach (var character in characters)
            {
                this.GetCharacterDetails(character);
            }

            var response = this.CreateResponse(characters);

            var result = this.bulkResponseConverter.Convert(response);

            result.TotalCount = this.Count;
            result.SubtotalCount = result.Count;

            return result;
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Character> IRepository<Guid, Character>.FindAll()
        {
            ICollection<CharacterDataContract> characters = this.CharactersDbSet.ToList();

            foreach (var character in characters)
            {
                this.GetCharacterDetails(character);
            }

            var response = this.CreateResponse(characters);
            var result = this.bulkResponseConverter.Convert(response);
            result.TotalCount = this.Count;
            result.SubtotalCount = result.Count;

            return result;
        }

        /// <inheritdoc />
        void IWriteable<Character>.Write(Character data)
        {
            var writeData = this.writeConverter.Convert(data);

            this.CharactersDbSet.Add(writeData);
            this.SaveChanges();
        }

        /// <inheritdoc />
        void IWriteable<Character>.WriteAsync(Character data)
        {
            ICharacterRepository self = this;
            self.WriteAsync(data, CancellationToken.None);
        }

        /// <inheritdoc />
        void IWriteable<Character>.WriteAsync(Character data, CancellationToken cancellationToken)
        {
            var writeData = this.writeConverter.Convert(data);

            this.CharactersDbSet.Add(writeData);
            this.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Characters");
        }

        /// <summary>Creates a response.</summary>
        /// <param name="content">The content.</param>
        /// <param name="cultureInfo">The culture info.</param>
        /// <param name="dateTimeOffset">The date time offset.</param>
        /// <typeparam name="TData">The type of the data.</typeparam>
        /// <returns>The <see cref="IResponse{TData}"/>.</returns>
        private IResponse<TData> CreateResponse<TData>(TData content, CultureInfo cultureInfo = null, DateTimeOffset? dateTimeOffset = null)
        {
            return new Response<TData> { Content = content, Culture = cultureInfo, Date = dateTimeOffset };
        }

        /// <summary>Gets the details of a character.</summary>
        /// <param name="character">The character.s</param>
        private void GetCharacterDetails(CharacterDataContract character)
        {
            character.Appearance = this.Set<PhysicalApperance>().Single(a => a.CharacterId == character.Id);
        }
    }
}
