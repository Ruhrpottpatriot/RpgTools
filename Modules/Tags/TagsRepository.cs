// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagsRepository.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the TagsRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Tags
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;
    using EntityFramework.Extensions;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;
    using RpgTools.Tags.Migrations;

    /// <summary>Provides methods and properties to read and store <see cref="Tag"/> objects from the database.</summary>
    public sealed class TagsRepository : DbContext, ITagsRepository
    {
        /// <summary>Holds a reference to the response converter.
        /// </summary>
        private readonly IConverter<IDataContainer<TagItem>, Tag> readConverter;

        /// <summary>Holds a reference to the response bulk response converter.</summary>
        private readonly IConverter<IDataContainer<ICollection<TagItem>>, IDictionaryRange<Guid, Tag>> bulkReadConverter;

        /// <summary>Holds a reference to the response write converter.</summary>
        private readonly IConverter<IDataContainer<Tag>, TagItem> writeConverter;

        /// <summary>Initialises a new instance of the <see cref="TagsRepository"/> class.</summary>
        /// <param name="tagReadConverter">The converter that converts <see cref="TagItem"/> into <see cref="Tag">Tags</see>.</param>
        /// <param name="tagWriteConverter">The converter that converts <see cref="Tag">Tags</see> into <see cref="TagItem"/>.</param>
        internal TagsRepository(IConverter<TagItem, Tag> tagReadConverter, IConverter<Tag, TagItem> tagWriteConverter)
            : base("name=RpgTools")
        {
            // Set the initializer. ToDo: Needs to be changed for production enviroment.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TagsRepository, Configuration>(true));
            this.Tags = this.Set<TagItem>();

            this.readConverter = new DataConverter<TagItem, Tag>(tagReadConverter);
            this.bulkReadConverter = new DictionaryRangeConverter<TagItem, Guid, Tag>(tagReadConverter, t => t.Id);
            this.writeConverter = new DataConverter<Tag, TagItem>(tagWriteConverter);
        }

        /// <inheritdoc />
        public CultureInfo Culture { get; set; }

        /// <summary>Gets or sets  internally stored tags.</summary>
        internal DbSet<TagItem> Tags { get; set; }

        /// <inheritdoc />
        public Tag Find(Guid identifier)
        {
            IDataContainer<TagItem> data = this.CreateContainer(
                this.Tags.SingleOrDefault(tag => tag.TwoLetterLanguageCode == this.Culture.TwoLetterISOLanguageName && tag.Id == identifier),
                this.Culture);
                
            return this.readConverter.Convert(data);
        }

        /// <inheritdoc />
        public IDictionaryRange<Guid, Tag> FindByType(string type)
        {
            IDataContainer<ICollection<TagItem>> data = this.CreateContainer<ICollection<TagItem>>(
                this.Tags.Where(tag => tag.TwoLetterLanguageCode == this.Culture.TwoLetterISOLanguageName && tag.Type == type).ToList(),
                this.Culture);

            return this.bulkReadConverter.Convert(data);
        }

        /// <inheritdoc />
        public IDictionaryRange<Guid, Tag> FindAll(ICollection<Guid> identifiers)
        {
            IDataContainer<ICollection<TagItem>> data = this.CreateContainer<ICollection<TagItem>>(
                this.Tags.Where(t => t.TwoLetterLanguageCode == this.Culture.TwoLetterISOLanguageName && identifiers.Any(i => i == t.Id)).ToList(),
                this.Culture);

            return this.bulkReadConverter.Convert(data);
        }

        /// <inheritdoc />
        public IDictionaryRange<Guid, Tag> FindAll()
        {
            IDataContainer<ICollection<TagItem>> data = this.CreateContainer<ICollection<TagItem>>(
                this.Tags.Where(t => t.TwoLetterLanguageCode == this.Culture.TwoLetterISOLanguageName).ToList(),
                this.Culture);

            return this.bulkReadConverter.Convert(data);
        }

        /// <inheritdoc />
        public void Create(IDataContainer<Tag> data)
        {
            TagItem contract = this.writeConverter.Convert(data);
            this.Tags.Add(contract);
            this.SaveChanges();
        }

        /// <inheritdoc />
        public void Update(IDataContainer<Tag> data)
        {
            TagItem updatedData = this.writeConverter.Convert(data);
            this.Tags.AddOrUpdate(updatedData);
            this.SaveChanges();
        }

        /// <summary>Deletes an item in the repository.</summary>
        /// <param name="identifier">The identifier that uniquely identifies an item in the repository.</param>
        public void Delete(Guid identifier)
        {
            this.Tags.Where(t => t.Id == identifier).Delete();
            this.SaveChanges();
        }

        /// <inheritdoc />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Tags");
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