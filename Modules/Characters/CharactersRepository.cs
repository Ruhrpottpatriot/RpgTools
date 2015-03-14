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
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using Characters.Converters;
    using Characters.DataContracts;
    using Characters.Requests;

    using RpgTools.Core.Common;
    using RpgTools.Core.Common.Converter;
    using RpgTools.Core.Models.Characters;

    /// <summary>The characters repository.</summary>
    public sealed class CharactersRepository : ICharacterRepository
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly DatabaseServiceClient<CharacterContext> serviceClient;

        /// <summary>Infrastructure. Holds a reference to the identifiers converter.</summary>
        private readonly IConverter<IResponse<ICollection<Guid>>, ICollection<Guid>> identifiersConverter;

        /// <summary>Infrastructure. Holds a reference to the response converter.</summary>
        private readonly IConverter<IResponse<CharacterDataContract>, Character> responseConverter;

        /// <summary>Infrastructure. Holds a reference to the write converter.</summary>
        private readonly IConverter<Character, CharacterDataContract> writeConverter;

        /// <summary>Infrastructure. Holds a reference to the bulk response converter.</summary>
        private readonly IConverter<IResponse<ICollection<CharacterDataContract>>, IDictionaryRange<Guid, Character>> bulkResponseConverter;

        /// <summary>Initialises a new instance of the <see cref="CharactersRepository"/> class.</summary>
        /// <param name="serviceClient">The service client to use.</param>
        public CharactersRepository(DatabaseServiceClient<CharacterContext> serviceClient)
            : this(serviceClient, new ConverterAdapter<ICollection<Guid>>(), new CharacterConverter(), new CharacterDataContractConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="CharactersRepository"/> class.</summary>
        /// <param name="serviceClient">The service client to use.</param>
        /// <param name="identifiersConverter">The identifiers Converter.</param>
        /// <param name="characterResponseConverter">The character response converter. </param>
        /// <param name="writeConverter">The write converter.</param>
        internal CharactersRepository(DatabaseServiceClient<CharacterContext> serviceClient, IConverter<ICollection<Guid>, ICollection<Guid>> identifiersConverter, IConverter<CharacterDataContract, Character> characterResponseConverter, IConverter<Character, CharacterDataContract> writeConverter)
        {
            this.serviceClient = serviceClient;

            this.identifiersConverter = new ResponseConverter<ICollection<Guid>, ICollection<Guid>>(identifiersConverter);

            this.responseConverter = new ResponseConverter<CharacterDataContract, Character>(characterResponseConverter);
            this.bulkResponseConverter = new DictionaryRangeConverter<CharacterDataContract, Guid, Character>(characterResponseConverter, c => c.Metadata.Id);

            this.writeConverter = writeConverter;
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<Guid> IDiscoverable<Guid>.Discover()
        {
            var request = new CharacterDiscoveryRequest();
            var response = this.serviceClient.Query(request);
            return this.identifiersConverter.Convert(response);
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
            var request = new CharacterDiscoveryRequest();
            var response = this.serviceClient.QueryAsync(request, cancellationToken);
            return response.ContinueWith<ICollection<Guid>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Character IRepository<Guid, Character>.Find(Guid identifier)
        {
            var request = new CharacterDetailsRequest { Identifier = identifier };
            var response = this.serviceClient.Query(request);
            return this.responseConverter.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Character> IRepository<Guid, Character>.FindAll(ICollection<Guid> identifiers)
        {
            var request = new CharacterBulkRequest { Identifiers = identifiers };
            var response = this.serviceClient.Query(request);

            // ToDo: Implement subtotal routine.
            // result.TotalCount = this.Count;
            // result.SubtotalCount = result.Count;
            return this.bulkResponseConverter.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Character> IRepository<Guid, Character>.FindAll()
        {
            var request = new CharacterCompleteRequest();
            var response = this.serviceClient.Query(request);

            // ToDo: Implement subtotal routine.
            // result.TotalCount = this.Count;
            // result.SubtotalCount = result.Count;
            return this.bulkResponseConverter.Convert(response);
        }

        /// <inheritdoc />
        void IWriteable<Character>.Write(Character data)
        {
            var writeData = this.writeConverter.Convert(data);

            this.serviceClient.Send(c => c.Characters.AddOrUpdate(writeData));
            this.serviceClient.Send(c => c.SaveChanges());
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
            // var writeData = this.writeConverter.Convert(data);
            // this.CharactersDbSet.Add(writeData);
            // this.SaveChangesAsync(cancellationToken);
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        void IWriteable<Character>.Delete(Character data)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        void IWriteable<Character>.DeleteAsync(Character data)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        void IWriteable<Character>.DeleteAsync(Character data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>Converts an async response.</summary>
        /// <param name="task">The task to convert.</param>
        /// <returns>The <see cref="ICollection{T}"/>.</returns>
        private ICollection<Guid> ConvertAsyncResponse(Task<IResponse<ICollection<Guid>>> task)
        {
            var ids = this.identifiersConverter.Convert(task.Result);

            return ids ?? new List<Guid>(0);
        }
    }
}
