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
    using System.Globalization;
    using System.Linq;

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

        /// <summary>Initialises a new instance of the <see cref="CharacterRepository"/> class.</summary>
        /// <param name="characterReadConverter">The character data contract converter.</param>
        /// <param name="characterWriteConverter">The character Write Converter.</param>
        internal CharacterRepository(IConverter<CharacterItem, Character> characterReadConverter, IConverter<Character, CharacterItem> characterWriteConverter)
            : base("name=RpgTools")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CharacterRepository, Configuration>(true));
            this.Characters = this.Set<CharacterItem>();

            this.readConverter = new DataConverter<CharacterItem, Character>(characterReadConverter);
            this.bulkReadConverter = new DictionaryRangeConverter<CharacterItem, Guid, Character>(characterReadConverter, c => c.Id);
            this.writeConverter = new DataConverter<Character, CharacterItem>(characterWriteConverter);
        }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the internal character list.</summary>
        internal DbSet<CharacterItem> Characters { get; private set; }

        /// <inheritdoc />
        public Character Find(Guid identifier)
        {
            IDataContainer<CharacterItem> data = this.CreateContainer(
                this.Characters.Include(c => c.Appearance).Include(c => c.Metadata).Single(c => c.Id == identifier),
                this.Culture);

            return this.readConverter.Convert(data);
        }

        /// <inheritdoc />
        public IDictionaryRange<Guid, Character> FindAll(ICollection<Guid> identifiers)
        {
            IDataContainer<ICollection<CharacterItem>> data = this.CreateContainer<ICollection<CharacterItem>>(
                this.Characters.Include(c => c.Appearance).Include(c => c.Metadata).Where(c => identifiers.Any(i => i == c.Id)).ToList(),
                this.Culture);

            return this.bulkReadConverter.Convert(data);
        }

        /// <inheritdoc />
        public IDictionaryRange<Guid, Character> FindAll()
        {
            IDataContainer<ICollection<CharacterItem>> data = this.CreateContainer<ICollection<CharacterItem>>(
               this.Characters.Include(c => c.Appearance).Include(c => c.Metadata).ToList(),
               this.Culture);

            return this.bulkReadConverter.Convert(data);
        }

        /// <inheritdoc />
        public void Delete(Guid data)
        {
            this.Characters.Where(c => c.Id == data).Delete();
            this.SaveChanges();
        }

        /// <summary>Creates a new item in the repository.</summary>
        /// <param name="data">The data to write to the repository.</param>
        public void Create(IDataContainer<Character> data)
        {
            CharacterItem convertedData = this.writeConverter.Convert(data);
            this.Characters.Add(convertedData);
            this.SaveChanges();
        }

        /// <summary>Updates an item in the repository with the given data.</summary>
        /// <param name="data">The new data to store in the repository.</param>
        public void Update(IDataContainer<Character> data)
        {
            CharacterItem convertedData = this.writeConverter.Convert(data);
            this.Characters.AddOrUpdate(convertedData);
            this.SaveChanges();
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
