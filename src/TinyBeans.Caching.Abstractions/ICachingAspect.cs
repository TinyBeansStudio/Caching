using System;
using System.Threading.Tasks;
using TinyBeans.Caching.Options;

namespace TinyBeans.Caching {

    /// <summary>
    /// Represents a type used to wrap and cache method return values.
    /// </summary>
    public interface ICachingAspect {

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="R">The result type.</typeparam>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="method">The method to invoke.</param>
        /// <returns>The result of the invoked method.</returns>
        R Invoke<R>(string cacheKey, Func<R> method);

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="R">The result type.</typeparam>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="method">The method to invoke.</param>
        /// <param name="options">The caching options to use.</param>
        /// <returns>The result of the invoked method.</returns>
        R Invoke<R>(string cacheKey, Func<R> method, CachingOptions options);

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="R">The result type of the <see cref="Task"/>.</typeparam>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="method">The method to invoke.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task<R> InvokeAsync<R>(string cacheKey, Func<Task<R>> method);

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="R">The result type of the <see cref="Task"/>.</typeparam>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="method">The method to invoke.</param>
        /// <param name="options">The caching options to use.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task<R> InvokeAsync<R>(string cacheKey, Func<Task<R>> method, CachingOptions options);

        /// <summary>
        /// Removes the specified item from the cache.
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        void Remove(string cacheKey);

        /// <summary>
        /// Removes the specified item from the cache.
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task RemoveAsync(string cacheKey);
    }
}
