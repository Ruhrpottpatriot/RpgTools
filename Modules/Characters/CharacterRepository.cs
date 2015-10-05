// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterRepository.cs" company="Robert Logiewa">
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
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using EntityFramework.Extensions;

    using RpgTools.Characters.Migrations;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Repository for storing and retrieving characters in a database.</summary>
    internal sealed class CharacterRepository : DbContext, ICharacterRepository
    {
        /// <summary>Infrastructure. Holds a reference to the response converter.</summary>
        private readonly IConverter<IDataContainer<CharacterItem>, Character> readConverter;

        /// <summary>Infrastructure. Holds a reference to the bulk identifiers converter.</summary>
        private readonly IConverter<IDataContainer<ICollection<CharacterItem>>, IDictionaryRange<Guid, Character>> bulkReadConverter;

        /// <summary>Infrastructure. Holds a reference to the write converter.</summary>
        private readonly IConverter<IDataContainer<Character>, CharacterItem> writeConverter;

        /// <summary>Initializes a new instance of the <see cref="CharacterRepository"/> class.</summary>
        /// <param name="characterReadConverter">The character data contract converter.</param>
        /// <param name="characterWriteConverter">The character Write Converter.</param>
        public CharacterRepository(IConverter<CharacterItem, Character> characterReadConverter, IConverter<Character, CharacterItem> characterWriteConverter)
            : base("name=RpgTools")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CharacterRepository, Configuration>(true));
            this.Characters = this.Set<CharacterItem>();

            this.readConverter = new DataConverter<CharacterItem, Character>(characterReadConverter);
            this.bulkReadConverter = new DictionaryRangeConverter<CharacterItem, Guid, Character>(characterReadConverter, c => c.Id);
            this.writeConverter = new DataConverter<Character, CharacterItem>(characterWriteConverter);
        }

        /// <summary>Initializes a new instance of the <see cref="CharacterRepository"/> class.</summary>
        [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "Only used for Entity Framework. This class should not be used in live code.")]
        public CharacterRepository()
            : this(new CharacterReadConverter(), new CharacterWriteConverter())
        {
        }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the internal character list.</summary>
        internal DbSet<CharacterItem> Characters { get; }

        /// <inheritdoc />
        public Task<Character> FindAsync(Guid identifier)
        {
            return this.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        public async Task<Character> FindAsync(Guid identifier, CancellationToken cancellationToken)
        {
            Task<IDataContainer<CharacterItem>> data = Task.Run(() => this.CreateContainer(this.Characters.Include(c => c.Appearance).Include(c => c.Metadata).Single(c => c.Id == identifier), this.Culture, DateTimeOffset.UtcNow), cancellationToken);

            return this.readConverter.Convert(await data);
        }

        /// <inheritdoc />
        public Task<IDictionaryRange<Guid, Character>> FindAllAsync()
        {
            return this.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        public async Task<IDictionaryRange<Guid, Character>> FindAllAsync(ICollection<Guid> identifiers, CancellationToken cancellationToken)
        {
            Task<IDataContainer<ICollection<CharacterItem>>> data = Task.Run(
                () =>
                this.CreateContainer<ICollection<CharacterItem>>(
                    this.Characters
                    .Include(c => c.Appearance)
                    .Include(c => c.Metadata)
                    .Where(c => identifiers
                        .Any(i => i == c.Id))
                    .ToList(),
                    this.Culture,
                    DateTimeOffset.UtcNow), cancellationToken);

            return this.bulkReadConverter.Convert(await data);
        }

        /// <inheritdoc />
        public Task<IDictionaryRange<Guid, Character>> FindAllAsync(ICollection<Guid> identifiers)
        {
            return this.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        public async Task<IDictionaryRange<Guid, Character>> FindAllAsync(CancellationToken cancellationToken)
        {
            Task<IDataContainer<ICollection<CharacterItem>>> data = Task.Run(
                () => this.CreateContainer<ICollection<CharacterItem>>(
               this.Characters.Include(c => c.Appearance).Include(c => c.Metadata).ToList(),
               this.Culture,
               DateTimeOffset.UtcNow), cancellationToken);

            return this.bulkReadConverter.Convert(await data);
        }

        /// <summary>Deletes an item in the repository.</summary>
        /// <param name="identifier">The identifier that uniquely identifies an item in the repository.</param>
        public Task DeleteAsync(Guid identifier)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(Guid data, CancellationToken cancellationToken)
        {
            this.Characters.Where(c => c.Id == data).Delete();

            await this.SaveChangesAsync(cancellationToken);
        }

        /// <summary>Creates a new item in the repository.</summary>
        /// <param name="data">The data to write to the repository.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task CreateAsync(IDataContainer<Character> data)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task CreateAsync(IDataContainer<Character> data, CancellationToken cancellationToken)
        {
            CharacterItem convertedData = this.writeConverter.Convert(data);
            this.Characters.Add(convertedData);
            await this.SaveChangesAsync(cancellationToken);
        }

        /// <summary>Updates an item in the repository with the given data.</summary>
        /// <param name="data">The new data to store in the repository.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task UpdateAsync(IDataContainer<Character> data)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task UpdateAsync(IDataContainer<Character> data, CancellationToken cancellationToken)
        {
            CharacterItem convertedData = this.writeConverter.Convert(data);
            this.Characters.AddOrUpdate(convertedData);
            await this.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Characters");
        }

        /// <summary>Creates the appropriate data container for converting data.</summary>
        /// <typeparam name="TData">The type of content to store in the container.</typeparam>
        /// <param name="data">The data to store in the container.</param>
        /// <param name="culture">The language of the data.</param>
        /// <param name="date">The date the data was requested.</param>
        /// <returns>An <see cref="IDataContainer{T}"/> containing the data to be converted and optional language and data.</returns>
        private IDataContainer<TData> CreateContainer<TData>(TData data, CultureInfo culture = null, DateTimeOffset? date = null)
        {
            return new DataContainer<TData>
            {
                Content = data,
                Culture = culture,
                Date = date
            };
        }
    }
}
