using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using TinyBeans.Caching.Options;

namespace TinyBeans.Caching.Defaults {

    /// <summary>
    /// The default implementation of <see cref="ICachingAspect"/>.
    /// </summary>
    public class DefaultCachingAspect : ICachingAspect {
        private readonly ICachingSerializer _cachingSerializer;
        private readonly IDistributedCache _distributedCache;
        private readonly IOptionsMonitor<CachingOptions> _options;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cachingSerializer">Instance of a serializer used to serialize objects before caching.</param>
        /// <param name="distributedCache">Instance of a distributed cache used to cache results.</param>
        /// <param name="options">The caching options to be used.</param>
        public DefaultCachingAspect(ICachingSerializer cachingSerializer, IDistributedCache distributedCache, IOptionsMonitor<CachingOptions> options) {
            _cachingSerializer = cachingSerializer;
            _distributedCache = distributedCache;
            _options = options;
        }

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="R">The result type.</typeparam>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="method">The method to invoke.</param>
        /// <returns>The result of the invoked method.</returns>
        public R Invoke<R>(string cacheKey, Func<R> method) {
            return Invoke(cacheKey, method, _options.CurrentValue);
        }

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="R">The result type.</typeparam>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="method">The method to invoke.</param>
        /// <param name="options">The caching options to use.</param>
        /// <returns>The result of the invoked method.</returns>
        public R Invoke<R>(string cacheKey, Func<R> method, CachingOptions options) {
            if (_distributedCache.GetString(cacheKey) is string raw && !string.IsNullOrEmpty(raw)) {
                return _cachingSerializer.Deserialize<R>(raw);
            }

            var r = method();

            _distributedCache.SetString(cacheKey, _cachingSerializer.Serialize(r), new DistributedCacheEntryOptions() {
                AbsoluteExpirationRelativeToNow = options.AbsoluteExpiration ?? (TimeSpan?)null,
                SlidingExpiration = options.SlidingExpiration ?? (TimeSpan?)null
            });

            return r;
        }

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="R">The result type of the <see cref="Task"/>.</typeparam>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="method">The method to invoke.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        public async Task<R> InvokeAsync<R>(string cacheKey, Func<Task<R>> method) {
            return await InvokeAsync(cacheKey, method, _options.CurrentValue);
        }

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="R">The result type of the <see cref="Task"/>.</typeparam>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="method">The method to invoke.</param>
        /// <param name="options">The caching options to use.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        public async Task<R> InvokeAsync<R>(string cacheKey, Func<Task<R>> method, CachingOptions options) {
            if (await _distributedCache.GetStringAsync(cacheKey) is string raw && !string.IsNullOrEmpty(raw)) {
                return _cachingSerializer.Deserialize<R>(raw);
            }

            var r = await method();

            await _distributedCache.SetStringAsync(cacheKey, _cachingSerializer.Serialize(r), new DistributedCacheEntryOptions() {
                AbsoluteExpirationRelativeToNow = options.AbsoluteExpiration ?? (TimeSpan?)null,
                SlidingExpiration = options.SlidingExpiration ?? (TimeSpan?)null
            });

            return r;
        }

        /// <summary>
        /// Removes the specified item from the cache.
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        public void Remove(string cacheKey) {
            _distributedCache.Remove(cacheKey);
        }

        /// <summary>
        /// Removes the specified item from the cache.
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        public async Task RemoveAsync(string cacheKey) {
            await _distributedCache.RemoveAsync(cacheKey);
        }
    }
}
