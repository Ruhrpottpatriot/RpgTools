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
    using System.Threading;
    using System.Threading.Tasks;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;
    using RpgTools.Tags.Migrations;

    /// <summary>Provides methods and properties to read and store <see cref="Tag"/> objects from the database.</summary>
    public sealed class TagsRepository : DbContext, ITagsRepository
    {
        /// <summary>Holds a reference to the response converter.
        /// </summary>
        private readonly IConverter<IResponse<TagDataContract>, Tag> responseConverter;

        /// <summary>Holds a reference to the response bulk response converter.</summary>
        private readonly IConverter<IResponse<ICollection<TagDataContract>>, IDictionaryRange<Guid, Tag>> bulkResponseConverter;

        /// <summary>Holds a reference to the response write converter.</summary>
        private readonly IConverter<Tag, TagDataContract> writeConverter;

        /// <summary>Initialises a new instance of the <see cref="TagsRepository"/> class.</summary>
        public TagsRepository()
            : this(new TagDataContractConverter(), new TagConverter())
        {
            // Set the initializer. ToDo: Needs to be changed for production enviroment.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TagsRepository, Configuration>(true));

            this.Tags = this.Set<TagDataContract>();
        }

        /// <summary>Initialises a new instance of the <see cref="TagsRepository"/> class.</summary>
        /// <param name="tagDataContractConverter">The converter that converts <see cref="TagDataContract"/> into <see cref="Tag">Tags</see>.</param>
        /// <param name="tagConverter">The converter that converts <see cref="Tag">Tags</see> into <see cref="TagDataContract"/>.</param>
        internal TagsRepository(IConverter<TagDataContract, Tag> tagDataContractConverter, IConverter<Tag, TagDataContract> tagConverter)
            : base("name=RpgTools")
        {
            this.responseConverter = new ResponseConverter<TagDataContract, Tag>(tagDataContractConverter);
            this.bulkResponseConverter = new DictionaryRangeConverter<TagDataContract, Guid, Tag>(tagDataContractConverter, t => t.Id);
            this.writeConverter = tagConverter;
        }

        /// <summary>Gets or sets the locale.</summary>
        CultureInfo ILocalizable.Culture { get; set; }

        /// <summary>Gets or sets  internally stored tags.</summary>
        internal DbSet<TagDataContract> Tags { get; set; }

        /// <inheritdoc />
        IDictionaryRange<Guid, Tag> ITagsRepository.FindByType(string type)
        {
            var data = new Response<ICollection<TagDataContract>>
                       {
                           Content = this.Tags.Where(tag => tag.TwoLetterLanguageCode == ((ILocalizable)this).Culture.TwoLetterISOLanguageName && tag.Type == type).ToList(),
                           Culture = ((ILocalizable)this).Culture
                       };
            return this.bulkResponseConverter.Convert(data);
        }

        /// <inheritdoc />
        Tag IRepository<Guid, Tag>.Find(Guid identifier)
        {
            var data = new Response<TagDataContract>
            {
                Content = this.Tags.SingleOrDefault(tag => tag.TwoLetterLanguageCode == ((ILocalizable)this).Culture.TwoLetterISOLanguageName && tag.Id == identifier),
                Culture = ((ILocalizable)this).Culture
            };
            return this.responseConverter.Convert(data);
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Tag> IRepository<Guid, Tag>.FindAll(ICollection<Guid> identifiers)
        {
            var data = new Response<ICollection<TagDataContract>>
            {
                Content = this.Tags.Where(t => t.TwoLetterLanguageCode == ((ILocalizable)this).Culture.TwoLetterISOLanguageName && identifiers.Any(i => i == t.Id)).ToList(),
                Culture = ((ILocalizable)this).Culture
            };
            return this.bulkResponseConverter.Convert(data);
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Tag> IRepository<Guid, Tag>.FindAll()
        {
            var data = new Response<ICollection<TagDataContract>>
                       {
                           Content = this.Tags.Where(t => t.TwoLetterLanguageCode == ((ILocalizable)this).Culture.TwoLetterISOLanguageName).ToList(),
                           Culture = ((ILocalizable)this).Culture
                       };
            return this.bulkResponseConverter.Convert(data);
        }
        
        /// <summary>Writes the data to the repository.</summary>
        /// <param name="data">The data to write.</param>
        void IWriteable<Tag>.Write(Tag data)
        {
            var dataContract = this.writeConverter.Convert(data);
            this.Tags.AddOrUpdate(t => t.Id, dataContract);
        }

        /// <summary>Deletes a specific item from the database.</summary>
        /// <param name="data">The item to delete.</param>
        void IWriteable<Tag>.Delete(Tag data)
        {
            var dataContract = this.writeConverter.Convert(data);
            this.Tags.Remove(dataContract);
        }

        /// <inheritdoc />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Tags");
        }
    }
}