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
    public sealed class CharactersRepository : DbContext, ICharacterRepository
    {
        /// <summary>Infrastructure. Holds a reference to the response converter.</summary>
        private readonly IConverter<IResponse<CharacterDatabaseItem>, Character> readConverter;

        /// <summary>Infrastructure. Holds a reference to the bulk identifiers converter.</summary>
        private readonly IConverter<IResponse<ICollection<CharacterDatabaseItem>>, IDictionaryRange<Guid, Character>> bulkReadConverter;

        /// <summary>Infrastructure. Holds a reference to the write converter.</summary>
        private readonly IConverter<Character, CharacterDatabaseItem> writeConverter;

        /// <summary>Initialises a new instance of the <see cref="CharactersRepository"/> class.</summary>
        public CharactersRepository()
            : this(new CharacterReadConverter(), new CharacterWriteConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="CharactersRepository"/> class.</summary>
        /// <param name="characterReadConverter">The character data contract converter.</param>
        /// <param name="characterWriteConverter">The character Write Converter.</param>
        private CharactersRepository(IConverter<CharacterDatabaseItem, Character> characterReadConverter, IConverter<Character, CharacterDatabaseItem> characterWriteConverter)
            : base("name=RpgTools")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CharactersRepository, Configuration>(true));
            this.Characters = this.Set<CharacterDatabaseItem>();

            this.readConverter = new ResponseConverter<CharacterDatabaseItem, Character>(characterReadConverter);
            this.bulkReadConverter = new DictionaryRangeConverter<CharacterDatabaseItem, Guid, Character>(characterReadConverter, c => c.Id);
            this.writeConverter = characterWriteConverter;
        }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets the internal character list.</summary>
        internal DbSet<CharacterDatabaseItem> Characters { get; private set; }

        /// <inheritdoc />
        public Character Find(Guid identifier)
        {
            var data = new Response<CharacterDatabaseItem>
            {
                Content = this.Characters.Include(c => c.AppearanceDatabaseItem).Include(c => c.MetadataDatabaseItem).Single(c => c.Id == identifier),
                Culture = this.Culture
            };
            return this.readConverter.Convert(data);
        }

        /// <inheritdoc />
        public IDictionaryRange<Guid, Character> FindAll(ICollection<Guid> identifiers)
        {
            var data = new Response<ICollection<CharacterDatabaseItem>>
            {
                Content = this.Characters.Include(c => c.AppearanceDatabaseItem).Include(c => c.MetadataDatabaseItem).Where(c => identifiers.Any(i => i == c.Id)).ToList(),
                Culture = this.Culture
            };
            return this.bulkReadConverter.Convert(data);
        }

        /// <inheritdoc />
        public IDictionaryRange<Guid, Character> FindAll()
        {
            var data = new Response<ICollection<CharacterDatabaseItem>>
            {
                Content = this.Characters.Include(c => c.AppearanceDatabaseItem).Include(c => c.MetadataDatabaseItem).ToList(),
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
