using System;

namespace TinyBeans.Caching.Options {

    /// <summary>
    /// Options used by the <see cref="ICachingAspect"/>.
    /// </summary>
    public class CachingOptions {

        /// <summary>
        /// The maximum amount of time a result can be cached before going stale.
        /// </summary>
        public TimeSpan? AbsoluteExpiration { get; set; }

        /// <summary>
        /// The amount of time a result can be cached without being accessed before going stale.
        /// </summary>
        public TimeSpan? SlidingExpiration { get; set; }
    }
}
