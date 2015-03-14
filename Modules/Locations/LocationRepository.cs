// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationRepository.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using RpgTools.Core.Common;
    using RpgTools.Core.Common.Converter;
    using RpgTools.Core.Models.Locations;
    using RpgTools.Locations.Converter;
    using RpgTools.Locations.DataContracts;
    using RpgTools.Locations.Requests;

    /// <summary>The location repository.</summary>
    public sealed class LocationRepository : ILocationRepository
    {
        /// <summary>Infrastructure. Holds a reference to the identifiers converter.</summary>
        private readonly IConverter<IResponse<ICollection<Guid>>, ICollection<Guid>> identifiersConverter;

        /// <summary>Infrastructure. Holds a reference to the response converter.</summary>
        private readonly IConverter<IResponse<LocationDataContract>, Location> responseConverter;

        /// <summary>Infrastructure. Holds a reference to the write converter.</summary>
        private readonly IConverter<Location, LocationDataContract> writeConverter;

        /// <summary>Infrastructure. Holds a reference to the bulk response converter.</summary>
        private readonly IConverter<IResponse<ICollection<LocationDataContract>>, IDictionaryRange<Guid, Location>> dictionaryRangeResponseConverter;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly DatabaseServiceClient<LocationContext> serviceClient;

        /// <summary>Initialises a new instance of the <see cref="LocationRepository"/> class.</summary>
        public LocationRepository()
            : this(new DatabaseServiceClient<LocationContext>(new LocationContext()), new LocationConverter(), new ConverterAdapter<ICollection<Guid>>(), new LocationDataContractConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="LocationRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="locationConverter">The location converter.</param>
        /// <param name="collectionConverter">The collection Converter.</param>
        /// <param name="writeConverter">The write Converter.</param>
        internal LocationRepository(DatabaseServiceClient<LocationContext> serviceClient, IConverter<LocationDataContract, Location> locationConverter, IConverter<ICollection<Guid>, ICollection<Guid>> collectionConverter, IConverter<Location, LocationDataContract> writeConverter)
        {
            this.serviceClient = serviceClient;

            this.identifiersConverter = new ResponseConverter<ICollection<Guid>, ICollection<Guid>>(collectionConverter);
            this.responseConverter = new ResponseConverter<LocationDataContract, Location>(locationConverter);
            this.dictionaryRangeResponseConverter = new DictionaryRangeConverter<LocationDataContract, Guid, Location>(locationConverter, location => location.Id);

            this.writeConverter = writeConverter;
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<Guid> IDiscoverable<Guid>.Discover()
        {
            var request = new LocationDatabaseDiscoveryRequest();
            var response = this.serviceClient.Query(request);
            return this.identifiersConverter.Convert(response) ?? new List<Guid>(0);
        }

        /// <inheritdoc />
        Task<ICollection<Guid>> IDiscoverable<Guid>.DiscoverAsync()
        {
            ILocationRepository self = this;
            return self.DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<Guid>> IDiscoverable<Guid>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new LocationDatabaseDiscoveryRequest();
            var responseTask = this.serviceClient.QueryAsync(request, cancellationToken);
            return responseTask.ContinueWith<ICollection<Guid>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Location IRepository<Guid, Location>.Find(Guid identifier)
        {
            var request = new LocationDetailsRequest()
            {
                Identifier = identifier
            };

            var response = this.serviceClient.Query(request);
            return this.responseConverter.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Location> IRepository<Guid, Location>.FindAll(ICollection<Guid> identifiers)
        {
            var request = new LocationBulkDatabaseRequest { Identifiers = identifiers };
            var response = this.serviceClient.Query(request);
            return this.dictionaryRangeResponseConverter.Convert(response);

            // ToDo: Implement subtotal routine.
            // result.TotalCount = this.LocationsDbSet.Count();
            // result.SubtotalCount = result.Count;
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Location> IRepository<Guid, Location>.FindAll()
        {
            var request = new LocationCompleteDatabaseRequest();
            var response = this.serviceClient.Query(request);

            return this.dictionaryRangeResponseConverter.Convert(response);
            
            // ToDo: Implement subtotal routine.
            // result.SubtotalCount = result.Count;
            // result.TotalCount = result.Count;
        }

        /// <inheritdoc />
        void IWriteable<Location>.Write(Location data)
        {
            var dataContractToWrite = this.writeConverter.Convert(data);

            this.serviceClient.Send(c => c.Locations.AddOrUpdate(dataContractToWrite));

            this.serviceClient.Send(c => c.SaveChanges());
        }

        /// <inheritdoc />
        void IWriteable<Location>.WriteAsync(Location data)
        {
            ILocationRepository self = this;
            self.WriteAsync(data, CancellationToken.None);
        }

        /// <inheritdoc />
        void IWriteable<Location>.WriteAsync(Location data, CancellationToken cancellationToken)
        {
            // var dataContractToWrite = this.writeConverter.Convert(data);
            // this.LocationsDbSet.AddOrUpdate(dataContractToWrite);
            // this.SaveChangesAsync(cancellationToken);
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        void IWriteable<Location>.Delete(Location data)
        {
            var contract = this.writeConverter.Convert(data);

            this.serviceClient.Send(c => c.Locations.Remove(contract));
            this.serviceClient.Send(c => c.SaveChanges());
        }

        /// <inheritdoc />
        void IWriteable<Location>.DeleteAsync(Location data)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        void IWriteable<Location>.DeleteAsync(Location data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private ICollection<Guid> ConvertAsyncResponse(Task<IResponse<ICollection<Guid>>> task)
        {
            var ids = this.identifiersConverter.Convert(task.Result);

            return ids ?? new List<Guid>(0);
        }
    }
}
