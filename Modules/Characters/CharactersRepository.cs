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
        private readonly IConverter<IResponse<CharacterDatabaseItem>, Character> readConverter;

        /// <summary>Infrastructure. Holds a reference to the bulk identifiers converter.</summary>
        private readonly IConverter<IResponse<ICollection<CharacterDatabaseItem>>, IDictionaryRange<Guid, Character>> bulkReadConverter;

        /// <summary>Infrastructure. Holds a reference to the write converter.</summary>
        private readonly IConverter<Character, CharacterDatabaseItem> writeConverter;

        /// <summary>Initialises a new instance of the <see cref="CharactersRepository"/> class.</summary>
        public CharactersRepository()
            : this(new CharacterReadConverter(), new CharacterWriteConverter())
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CharactersRepository, Configuration>(true));

            this.Characters = this.Set<CharacterDatabaseItem>();
        }

        /// <summary>Initialises a new instance of the <see cref="CharactersRepository"/> class.</summary>
        /// <param name="characterReadConverter">The character data contract converter.</param>
        /// <param name="characterWriteConverter">The character Write Converter.</param>
        internal CharactersRepository(IConverter<CharacterDatabaseItem, Character> characterReadConverter, IConverter<Character, CharacterDatabaseItem> characterWriteConverter)
            : base("name=RpgTools")
        {
            this.readConverter = new ResponseConverter<CharacterDatabaseItem, Character>(characterReadConverter);
            this.bulkReadConverter = new DictionaryRangeConverter<CharacterDatabaseItem, Guid, Character>(characterReadConverter, c => c.Id);
            this.writeConverter = characterWriteConverter;
        }

        /// <summary>Gets or sets the locale.</summary>
        CultureInfo ILocalizable.Culture { get; set; }

        /// <summary>Gets or sets the internal character list.</summary>
        internal DbSet<CharacterDatabaseItem> Characters { get; set; }

        /// <inheritdoc />
        Character IRepository<Guid, Character>.Find(Guid identifier)
        {
            var data = new Response<CharacterDatabaseItem>
            {
                Content = this.Characters.Include(c => c.AppearanceDatabaseItem).Include(c => c.MetadataDatabaseItem).Single(c => c.Id == identifier),
                Culture = ((ILocalizable)this).Culture
            };
            return this.readConverter.Convert(data);
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Character> IRepository<Guid, Character>.FindAll(ICollection<Guid> identifiers)
        {
            var data = new Response<ICollection<CharacterDatabaseItem>>
                       {
                           Content = this.Characters.Include(c => c.AppearanceDatabaseItem).Include(c => c.MetadataDatabaseItem).Where(c => identifiers.Any(i => i == c.Id)).ToList(),
                           Culture = ((ILocalizable)this).Culture
                       };
            return this.bulkReadConverter.Convert(data);
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Character> IRepository<Guid, Character>.FindAll()
        {
            var data = new Response<ICollection<CharacterDatabaseItem>>
            {
                Content = this.Characters.Include(c => c.AppearanceDatabaseItem).Include(c => c.MetadataDatabaseItem).ToList(),
                Culture = ((ILocalizable)this).Culture
            };
            return this.bulkReadConverter.Convert(data);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<Guid, Character>> IRepository<Guid, Character>.FindAllAsync()
        {
            return ((ICharacterRepository)this).FindAllAsync(CancellationToken.None);
        }

        /// <summary>Writes the data to the repository.</summary>
        /// <param name="data">The data to write.</param>
        void IWriteable<Character>.Write(Character data)
        {
            var writeData = this.writeConverter.Convert(data);
            this.Characters.AddOrUpdate(c => c.Id, writeData);
            this.SaveChanges();
        }

        /// <summary>Writes the data to the repository asynchronously.</summary>
        /// <param name="data">The data to write.</param>
        void IWriteable<Character>.WriteAsync(Character data)
        {
            ((IWriteable<Character>)this).WriteAsync(data, CancellationToken.None);
        }

        /// <summary>Writes the data to the repository asynchronously.</summary>
        /// <param name="data">The data to write.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        void IWriteable<Character>.WriteAsync(Character data, CancellationToken cancellationToken)
        {
            var writeData = this.writeConverter.Convert(data);
            this.Characters.AddOrUpdate(c => c.Id, writeData);
            this.SaveChangesAsync(cancellationToken);
        }

        /// <summary>Deletes a specific item from the database.</summary>
        /// <param name="data">The item to delete.</param>
        void IWriteable<Character>.Delete(Character data)
        {
            var writeData = this.writeConverter.Convert(data);
            this.Characters.Remove(writeData);
            this.SaveChanges();
        }

        /// <summary>Asynchronously deletes a specific item from the database.</summary>
        /// <param name="data">The item to delete.</param>
        void IWriteable<Character>.DeleteAsync(Character data)
        {
            ((IWriteable<Character>)this).DeleteAsync(data, CancellationToken.None);
        }

        /// <summary>Asynchronously deletes a specific item from the database.</summary>
        /// <param name="data">The item to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        void IWriteable<Character>.DeleteAsync(Character data, CancellationToken cancellationToken)
        {
            var writeData = this.writeConverter.Convert(data);
            this.Characters.Remove(writeData);
            this.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<Guid, Character>> IRepository<Guid, Character>.FindAllAsync(CancellationToken cancellationToken)
        {
            var data = new Response<ICollection<CharacterDatabaseItem>>
                       {
                           Content = await this.Characters.Include(c => c.AppearanceDatabaseItem).Include(c => c.MetadataDatabaseItem).ToListAsync(cancellationToken),
                           Culture = ((ILocalizable)this).Culture
                       };

            return this.bulkReadConverter.Convert(data);
        }

        /// <inheritdoc />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Characters");
        }
    }
}
