// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationRepository.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RpgTools.Locations
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using RpgTools.Core.Common;
    using RpgTools.Core.Common.Converter;
    using RpgTools.Core.Models;
    using RpgTools.Locations.Converter;
    using RpgTools.Locations.DataContracts;

    /// <summary>The location repository.</summary>
    public sealed class LocationRepository : ILocationRepository, IDisposable
    {
        /// <summary>Infrastructure. Holds a reference to the identifiers converter.</summary>
        private readonly IConverter<IResponse<ICollection<Guid>>, ICollection<Guid>> identifiersConverter;

        /// <summary>Infrastructure. Holds a reference to the response converter.</summary>
        private readonly IConverter<IResponse<LocationDataContract>, Location> responseConverter;

        /// <summary>Infrastructure. Holds a reference to the write converter.</summary>
        private readonly IConverter<Location, LocationDataContract> writeConverter;

        /// <summary>Infrastructure. Holds a reference to the bulk response converter.</summary>
        private readonly IConverter<IResponse<ICollection<LocationDataContract>>, IDictionaryRange<Guid, Location>> dictionaryRangeResponseConverter;
        
        /// <summary>Infrastructure. Holds a reference to the location context.</summary>
        private LocationContext context;

        /// <summary>Initialises a new instance of the <see cref="LocationRepository"/> class.</summary>
        /// <param name="serviceClient">The service Client.</param>
        public LocationRepository()
            : this(new LocationConverter(), new ConverterAdapter<ICollection<Guid>>(), new LocationDataContractConverter())
        {
        }

        /// <summary>Initialises a new instance of the <see cref="LocationRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="locationConverter">The location converter.</param>
        /// <param name="collectionConverter">The collection Converter.</param>
        /// <param name="writeConverter">The write Converter.</param>
        internal LocationRepository(IConverter<LocationDataContract, Location> locationConverter, IConverter<ICollection<Guid>, ICollection<Guid>> collectionConverter, IConverter<Location, LocationDataContract> writeConverter)
        {
            this.context = new LocationContext();

            this.identifiersConverter = new ResponseConverter<ICollection<Guid>, ICollection<Guid>>(collectionConverter);
            this.responseConverter = new ResponseConverter<LocationDataContract, Location>(locationConverter);
            this.dictionaryRangeResponseConverter = new DictionaryRangeConverter<LocationDataContract, Guid, Location>(locationConverter, location => location.Id);

            this.writeConverter = writeConverter;
        }

        /// <summary>Finalises an instance of the <see cref="LocationRepository"/> class.</summary>
        ~LocationRepository()
        {
            this.Dispose(false);
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<Guid> IDiscoverable<Guid>.Discover()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        Location IRepository<Guid, Location>.Find(Guid identifier)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Location> IRepository<Guid, Location>.FindAll(ICollection<Guid> identifiers)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Location> IRepository<Guid, Location>.FindAll()
        {
            throw new NotImplementedException();
        }

        Task<IDictionaryRange<Guid, Location>> IRepository<Guid, Location>.FindAllAsync()
        {
            return ((ILocationRepository)this).FindAllAsync(CancellationToken.None);
        }

        Task<IDictionaryRange<Guid, Location>> IRepository<Guid, Location>.FindAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        void IWriteable<Location>.Write(Location data)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        void IWriteable<Location>.WriteAsync(Location data)
        {
            ((ILocationRepository)this).WriteAsync(data, CancellationToken.None);
        }

        /// <inheritdoc />
        void IWriteable<Location>.WriteAsync(Location data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        void IWriteable<Location>.Delete(Location data)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        void IWriteable<Location>.DeleteAsync(Location data)
        {
            ((ILocationRepository)this).DeleteAsync(data, CancellationToken.None);
        }

        /// <inheritdoc />
        void IWriteable<Location>.DeleteAsync(Location data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        /// <param name="disposing">True when we are disposing of this instance.</param>
        /// <filterpriority>2</filterpriority>
        internal void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.context.Dispose();
                this.context = null;
            }
        }

        /// <summary>Gets the result of the async response.</summary>
        /// <param name="task">The task to get the result from.</param>
        /// <returns>The <see cref="ICollection{T}"/>.</returns>
        private ICollection<Guid> ConvertAsyncResponse(Task<IResponse<ICollection<Guid>>> task)
        {
            var ids = this.identifiersConverter.Convert(task.Result);

            return ids ?? new List<Guid>(0);
        }
    }
}
