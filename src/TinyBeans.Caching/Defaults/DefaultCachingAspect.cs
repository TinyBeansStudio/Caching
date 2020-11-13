using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using TinyBeans.Caching.Options;

namespace TinyBeans.Caching.Defaults {
    public class DefaultCachingAspect : ICachingAspect {
        private readonly ICachingSerializer _cachingSerializer;
        private readonly IDistributedCache _distributedCache;
        private readonly IOptionsMonitor<CachingOptions> _options;

        public DefaultCachingAspect(ICachingSerializer cachingSerializer, IDistributedCache distributedCache, IOptionsMonitor<CachingOptions> options) {
            _cachingSerializer = cachingSerializer;
            _distributedCache = distributedCache;
            _options = options;
        }

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="R">The result type.</typeparam>
        /// <param name="method">The method to invoke.</param>
        /// <returns>The result of the invoked method.</returns>
        public R Invoke<R>(Func<R> method) {
            var result = ReadCache<R>(method);
            if (result.Success) {
                return result.R;
            }

            var r = method();

            WriteCache<R>(method, r);

            return r;
        }

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="P1">The type of the first parameter to pass to the method.</typeparam>
        /// <typeparam name="R">The result type.</typeparam>
        /// <param name="method">The method to invoke.</param>
        /// <param name="p1">The first parameter to pass to the method.</param>
        /// <returns>The result of the invoked method.</returns>
        public R Invoke<P1, R>(Func<P1, R> method, P1 p1) {
            var result = ReadCache<R>(method);
            if (result.Success) {
                return result.R;
            }

            var r = method(p1);

            WriteCache<R>(method, r);

            return r;
        }

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="P1">The type of the first parameter to pass to the method.</typeparam>
        /// <typeparam name="P2">The type of the second parameter to pass to the method.</typeparam>
        /// <typeparam name="R">The result type.</typeparam>
        /// <param name="method">The method to invoke.</param>
        /// <param name="p1">The first parameter to pass to the method.</param>
        /// <param name="p2">The second parameter to pass to the method.</param>
        /// <returns>The result of the invoked method.</returns>
        public R Invoke<P1, P2, R>(Func<P1, P2, R> method, P1 p1, P2 p2) {
            var result = ReadCache<R>(method);
            if (result.Success) {
                return result.R;
            }

            var r = method(p1, p2);

            WriteCache<R>(method, r);

            return r;
        }

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="P1">The type of the first parameter to pass to the method.</typeparam>
        /// <typeparam name="P2">The type of the second parameter to pass to the method.</typeparam>
        /// <typeparam name="P3">The type of the third parameter to pass to the method.</typeparam>
        /// <typeparam name="R">The result type.</typeparam>
        /// <param name="method">The method to invoke.</param>
        /// <param name="p1">The first parameter to pass to the method.</param>
        /// <param name="p2">The second parameter to pass to the method.</param>
        /// <param name="p3">The third parameter to pass to the method.</param>
        /// <returns>The result of the invoked method.</returns>
        public R Invoke<P1, P2, P3, R>(Func<P1, P2, P3, R> method, P1 p1, P2 p2, P3 p3) {
            var result = ReadCache<R>(method);
            if (result.Success) {
                return result.R;
            }

            var r = method(p1, p2, p3);

            WriteCache<R>(method, r);

            return r;
        }

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="P1">The type of the first parameter to pass to the method.</typeparam>
        /// <typeparam name="P2">The type of the second parameter to pass to the method.</typeparam>
        /// <typeparam name="P3">The type of the third parameter to pass to the method.</typeparam>
        /// <typeparam name="P4">The type of the fourth parameter to pass to the method.</typeparam>
        /// <typeparam name="R">The result type.</typeparam>
        /// <param name="method">The method to invoke.</param>
        /// <param name="p1">The first parameter to pass to the method.</param>
        /// <param name="p2">The second parameter to pass to the method.</param>
        /// <param name="p3">The third parameter to pass to the method.</param>
        /// <param name="p4">The fourth parameter to pass to the method.</param>
        /// <returns>The result of the invoked method.</returns>
        public R Invoke<P1, P2, P3, P4, R>(Func<P1, P2, P3, P4, R> method, P1 p1, P2 p2, P3 p3, P4 p4) {
            var result = ReadCache<R>(method);
            if (result.Success) {
                return result.R;
            }

            var r = method(p1, p2, p3, p4);

            WriteCache<R>(method, r);

            return r;
        }

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="P1">The type of the first parameter to pass to the method.</typeparam>
        /// <typeparam name="P2">The type of the second parameter to pass to the method.</typeparam>
        /// <typeparam name="P3">The type of the third parameter to pass to the method.</typeparam>
        /// <typeparam name="P4">The type of the fourth parameter to pass to the method.</typeparam>
        /// <typeparam name="P5">The type of the fifth parameter to pass to the method.</typeparam>
        /// <typeparam name="R">The result type.</typeparam>
        /// <param name="method">The method to invoke.</param>
        /// <param name="p1">The first parameter to pass to the method.</param>
        /// <param name="p2">The second parameter to pass to the method.</param>
        /// <param name="p3">The third parameter to pass to the method.</param>
        /// <param name="p4">The fourth parameter to pass to the method.</param>
        /// <param name="p5">The fifth parameter to pass to the method.</param>
        /// <returns>The result of the invoked method.</returns>
        public R Invoke<P1, P2, P3, P4, P5, R>(Func<P1, P2, P3, P4, P5, R> method, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5) {
            var result = ReadCache<R>(method);
            if (result.Success) {
                return result.R;
            }

            var r = method(p1, p2, p3, p4, p5);

            WriteCache<R>(method, r);

            return r;
        }

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="R">The result type of the <see cref="Task"/>.</typeparam>
        /// <param name="method">The method to invoke.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        public async Task<R> InvokeAsync<R>(Func<Task<R>> method) {
            var result = await ReadCacheAsync<R>(method);
            if (result.Success) {
                return result.R;
            }

            var r = await method();

            await WriteCacheAsync<R>(method, r);

            return r;
        }

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="P1">The type of the first parameter to pass to the method.</typeparam>
        /// <typeparam name="R">The result type of the <see cref="Task"/>.</typeparam>
        /// <param name="method">The method to invoke.</param>
        /// <param name="p1">The first parameter to pass to the method.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        public async Task<R> InvokeAsync<P1, R>(Func<P1, Task<R>> method, P1 p1) {
            var result = await ReadCacheAsync<R>(method);
            if (result.Success) {
                return result.R;
            }

            var r = await method(p1);

            await WriteCacheAsync<R>(method, r);

            return r;
        }

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="P1">The type of the first parameter to pass to the method.</typeparam>
        /// <typeparam name="P2">The type of the second parameter to pass to the method.</typeparam>
        /// <typeparam name="R">The result type of the <see cref="Task"/>.</typeparam>
        /// <param name="method">The method to invoke.</param>
        /// <param name="p1">The first parameter to pass to the method.</param>
        /// <param name="p2">The second parameter to pass to the method.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        public async Task<R> InvokeAsync<P1, P2, R>(Func<P1, P2, Task<R>> method, P1 p1, P2 p2) {
            var result = await ReadCacheAsync<R>(method);
            if (result.Success) {
                return result.R;
            }

            var r = await method(p1, p2);

            await WriteCacheAsync<R>(method, r);

            return r;
        }

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="P1">The type of the first parameter to pass to the method.</typeparam>
        /// <typeparam name="P2">The type of the second parameter to pass to the method.</typeparam>
        /// <typeparam name="P3">The type of the third parameter to pass to the method.</typeparam>
        /// <typeparam name="R">The result type of the <see cref="Task"/>.</typeparam>
        /// <param name="method">The method to invoke.</param>
        /// <param name="p1">The first parameter to pass to the method.</param>
        /// <param name="p2">The second parameter to pass to the method.</param>
        /// <param name="p3">The third parameter to pass to the method.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        public async Task<R> InvokeAsync<P1, P2, P3, R>(Func<P1, P2, P3, Task<R>> method, P1 p1, P2 p2, P3 p3) {
            var result = await ReadCacheAsync<R>(method);
            if (result.Success) {
                return result.R;
            }

            var r = await method(p1, p2, p3);

            await WriteCacheAsync<R>(method, r);

            return r;
        }

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="P1">The type of the first parameter to pass to the method.</typeparam>
        /// <typeparam name="P2">The type of the second parameter to pass to the method.</typeparam>
        /// <typeparam name="P3">The type of the third parameter to pass to the method.</typeparam>
        /// <typeparam name="P4">The type of the fourth parameter to pass to the method.</typeparam>
        /// <typeparam name="R">The result type of the <see cref="Task"/>.</typeparam>
        /// <param name="method">The method to invoke.</param>
        /// <param name="p1">The first parameter to pass to the method.</param>
        /// <param name="p2">The second parameter to pass to the method.</param>
        /// <param name="p3">The third parameter to pass to the method.</param>
        /// <param name="p4">The fourth parameter to pass to the method.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        public async Task<R> InvokeAsync<P1, P2, P3, P4, R>(Func<P1, P2, P3, P4, Task<R>> method, P1 p1, P2 p2, P3 p3, P4 p4) {
            var result = await ReadCacheAsync<R>(method);
            if (result.Success) {
                return result.R;
            }

            var r = await method(p1, p2, p3, p4);

            await WriteCacheAsync<R>(method, r);

            return r;
        }

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="P1">The type of the first parameter to pass to the method.</typeparam>
        /// <typeparam name="P2">The type of the second parameter to pass to the method.</typeparam>
        /// <typeparam name="P3">The type of the third parameter to pass to the method.</typeparam>
        /// <typeparam name="P4">The type of the fourth parameter to pass to the method.</typeparam>
        /// <typeparam name="P5">The type of the fifth parameter to pass to the method.</typeparam>
        /// <typeparam name="R">The result type of the <see cref="Task"/>.</typeparam>
        /// <param name="method">The method to invoke.</param>
        /// <param name="p1">The first parameter to pass to the method.</param>
        /// <param name="p2">The second parameter to pass to the method.</param>
        /// <param name="p3">The third parameter to pass to the method.</param>
        /// <param name="p4">The fourth parameter to pass to the method.</param>
        /// <param name="p5">The fifth parameter to pass to the method.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        public async Task<R> InvokeAsync<P1, P2, P3, P4, P5, R>(Func<P1, P2, P3, P4, P5, Task<R>> method, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5) {
            var result = await ReadCacheAsync<R>(method);
            if (result.Success) {
                return result.R;
            }

            var r = await method(p1, p2, p3, p4, p5);

            await WriteCacheAsync<R>(method, r);

            return r;
        }

        private (bool Success, R R) ReadCache<R>(Delegate method) {
            var key = string.Concat(method.Target.GetType().FullName, ".", method.Method.Name);

            if (_distributedCache.GetString(key) is string raw) {
                return (true, _cachingSerializer.Deserialize<R>(raw));
            }

            return (false, default);
        }

        private async Task<(bool Success, R R)> ReadCacheAsync<R>(Delegate method) {
            var key = string.Concat(method.Target.GetType().FullName, ".", method.Method.Name);

            if (await _distributedCache.GetStringAsync(key) is string raw) {
                return (true, _cachingSerializer.Deserialize<R>(raw));
            }

            return (false, default);
        }

        private void WriteCache<R>(Delegate method, R obj) {
            var key = string.Concat(method.Target.GetType().FullName, ".", method.Method.Name);
            var raw = _cachingSerializer.Serialize(obj);
            var options = _options.CurrentValue;

            _distributedCache.SetString(key, raw, new DistributedCacheEntryOptions() {
                AbsoluteExpiration = DateTime.Now.Add(options.AbsoluteExpiration),
                SlidingExpiration = options.SlidingExpiration
            });
        }

        private async Task WriteCacheAsync<R>(Delegate method, R obj) {
            var key = string.Concat(method.Target.GetType().FullName, ".", method.Method.Name);
            var raw = _cachingSerializer.Serialize(obj);
            var options = _options.CurrentValue;

            await _distributedCache.SetStringAsync(key, raw, new DistributedCacheEntryOptions() {
                AbsoluteExpiration = DateTime.Now.Add(options.AbsoluteExpiration),
                SlidingExpiration = options.SlidingExpiration
            });
        }
    }
}
