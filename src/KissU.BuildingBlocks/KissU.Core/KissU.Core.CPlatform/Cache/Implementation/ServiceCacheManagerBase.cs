using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Serialization;

namespace KissU.Core.CPlatform.Cache.Implementation
{
    /// <summary>
    /// 服务缓存管理基类.
    /// Implements the <see cref="KissU.Core.CPlatform.Cache.IServiceCacheManager" />
    /// </summary>
    public abstract class ServiceCacheManagerBase : IServiceCacheManager
    {
        /// <summary>
        /// The serializer
        /// </summary>
        private readonly ISerializer<string> _serializer;

        /// <summary>
        /// The changed
        /// </summary>
        private EventHandler<ServiceCacheChangedEventArgs> _changed;

        /// <summary>
        /// The created
        /// </summary>
        private EventHandler<ServiceCacheEventArgs> _created;

        /// <summary>
        /// The removed
        /// </summary>
        private EventHandler<ServiceCacheEventArgs> _removed;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceCacheManagerBase" /> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        protected ServiceCacheManagerBase(ISerializer<string> serializer)
        {
            _serializer = serializer;
        }

        /// <summary>
        /// Occurs when [created].
        /// </summary>
        public event EventHandler<ServiceCacheEventArgs> Created
        {
            add => _created += value;
            remove => _created -= value;
        }

        /// <summary>
        /// Occurs when [removed].
        /// </summary>
        public event EventHandler<ServiceCacheEventArgs> Removed
        {
            add => _removed += value;
            remove => _removed -= value;
        }

        /// <summary>
        /// Occurs when [changed].
        /// </summary>
        public event EventHandler<ServiceCacheChangedEventArgs> Changed
        {
            add => _changed += value;
            remove => _changed -= value;
        }

        /// <summary>
        /// Clears the asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        public abstract Task ClearAsync();

        /// <summary>
        /// Gets the caches asynchronous.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;ServiceCache&gt;&gt;.</returns>
        public abstract Task<IEnumerable<ServiceCache>> GetCachesAsync();

        /// <summary>
        /// Remves the address asynchronous.
        /// </summary>
        /// <param name="endpoints">The endpoints.</param>
        /// <returns>Task.</returns>
        public abstract Task RemveAddressAsync(IEnumerable<CacheEndpoint> endpoints);

        /// <summary>
        /// Sets the caches asynchronous.
        /// </summary>
        /// <param name="caches">The caches.</param>
        /// <returns>Task.</returns>
        /// <exception cref="ArgumentNullException">caches</exception>
        public virtual Task SetCachesAsync(IEnumerable<ServiceCache> caches)
        {
            if (caches == null)
            {
                throw new ArgumentNullException(nameof(caches));
            }

            var descriptors = caches.Where(cache => cache != null).Select(cache => new ServiceCacheDescriptor
            {
                AddressDescriptors = cache.CacheEndpoint?.Select(address => new CacheEndpointDescriptor
                {
                    Type = address.GetType().FullName,
                    Value = _serializer.Serialize(address),
                }) ?? Enumerable.Empty<CacheEndpointDescriptor>(),
                CacheDescriptor = cache.CacheDescriptor,
            });
            return SetCachesAsync(descriptors);
        }

        /// <summary>
        /// Sets the caches asynchronous.
        /// </summary>
        /// <param name="cacheDescriptors">The cache descriptors.</param>
        /// <returns>Task.</returns>
        public abstract Task SetCachesAsync(IEnumerable<ServiceCacheDescriptor> cacheDescriptors);

        /// <summary>
        /// Called when [created].
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected void OnCreated(params ServiceCacheEventArgs[] args)
        {
            if (_created == null)
            {
                return;
            }

            foreach (var arg in args)
            {
                _created(this, arg);
            }
        }

        /// <summary>
        /// Called when [changed].
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected void OnChanged(params ServiceCacheChangedEventArgs[] args)
        {
            if (_changed == null)
            {
                return;
            }

            foreach (var arg in args)
            {
                _changed(this, arg);
            }
        }

        /// <summary>
        /// Called when [removed].
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected void OnRemoved(params ServiceCacheEventArgs[] args)
        {
            if (_removed == null)
            {
                return;
            }

            foreach (var arg in args)
            {
                _removed(this, arg);
            }
        }
    }
}