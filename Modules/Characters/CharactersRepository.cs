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
    using RpgTools.Characters.Migrations;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    /// <summary>Repository for storing and retrieving characters in a database.</summary>
    public sealed class CharactersReadableRepository : DbContext, ICharacterReadableRepository
    {
        /// <summary>Infrastructure. Holds a reference to the response converter.</summary>
        private readonly IConverter<IDataContainer<CharacterItem>, Character> readConverter;

        /// <summary>Infrastructure. Holds a reference to the bulk identifiers converter.</summary>
        private readonly IConverter<IDataContainer<ICollection<CharacterItem>>, IDictionaryRange<Guid, Character>> bulkReadConverter;

        /// <summary>Infrastructure. Holds a reference to the write converter.</summary>
        private readonly IConverter<Character, CharacterItem> writeConverter;

        /// <summary>Initialises a new instance of the <see cref="CharactersReadableRepository"/> class.</summary>
        public CharactersReadableRepository()
            : this(new CharacterReadConverter(), new CharacterWriteConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="CharactersReadableRepository"/> class.</summary>
        /// <param name="characterReadConverter">The character data contract converter.</param>
        /// <param name="characterWriteConverter">The character Write Converter.</param>
        private CharactersReadableRepository(IConverter<CharacterItem, Character> characterReadConverter, IConverter<Character, CharacterItem> characterWriteConverter)
            : base("name=RpgTools")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CharactersReadableRepository, Configuration>(true));
            this.Characters = this.Set<CharacterItem>();

            this.readConverter = new DataConverter<CharacterItem, Character>(characterReadConverter);
            this.bulkReadConverter = new DictionaryRangeConverter<CharacterItem, Guid, Character>(characterReadConverter, c => c.Id);
            this.writeConverter = characterWriteConverter;
        }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the internal character list.</summary>
        internal DbSet<CharacterItem> Characters { get; private set; }

        /// <inheritdoc />
        public Character Find(Guid identifier)
        {
            var data = new DataContainer<CharacterItem>
            {
                Content = this.Characters.Include(c => c.Appearance).Include(c => c.Metadata).Single(c => c.Id == identifier),
                Culture = this.Culture
            };
            return this.readConverter.Convert(data);
        }

        /// <inheritdoc />
        public IDictionaryRange<Guid, Character> FindAll(ICollection<Guid> identifiers)
        {
            var data = new DataContainer<ICollection<CharacterItem>>
            {
                Content = this.Characters.Include(c => c.Appearance).Include(c => c.Metadata).Where(c => identifiers.Any(i => i == c.Id)).ToList(),
                Culture = this.Culture
            };
            return this.bulkReadConverter.Convert(data);
        }

        /// <inheritdoc />
        public IDictionaryRange<Guid, Character> FindAll()
        {
            var data = new DataContainer<ICollection<CharacterItem>>
            {
                Content = this.Characters.Include(c => c.Appearance).Include(c => c.Metadata).ToList(),
                Culture = this.Culture
            };
            return this.bulkReadConverter.Convert(data);
        }

        /// <inheritdoc />
        public void Write(Character data)
        {
            var writeData = this.writeConverter.Convert(data);
            this.Characters.AddOrUpdate(c => c.Id, writeData);
            this.SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(Character data)
        {
            var writeData = this.writeConverter.Convert(data);
            this.Characters.Remove(writeData);
            this.SaveChanges();
        }

        /// <inheritdoc />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Characters");
        }
    }
}
