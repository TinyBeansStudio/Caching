using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TinyBeans.Caching.Defaults;
using TinyBeans.Caching.Options;

namespace TinyBeans.Caching {

    /// <summary>
    /// Extensions for <see cref="Caching"/>.
    /// </summary>
    public static class Extensions {

        /// <summary>
        /// Adds services required for using <see cref="ICachingAspect"/> using the default options.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddTinyLogging(this IServiceCollection services) {
            return services
                .AddSingleton<ICachingSerializer, DefaultCachingSerializer>()
                .AddSingleton<ICachingAspect, DefaultCachingAspect>()
                .Configure<CachingOptions>(options => { });
        }

        /// <summary>
        /// Adds services required for using <see cref="ICachingAspect"/> using the supplied options.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="options">The options type to be configured.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddTinyLogging(this IServiceCollection services, Action<CachingOptions> options) {
            return services
                .AddSingleton<ICachingSerializer, DefaultCachingSerializer>()
                .AddSingleton<ICachingAspect, DefaultCachingAspect>()
                .Configure<CachingOptions>(options);
        }

        /// <summary>
        /// Adds services required for using <see cref="ICachingAspect"/> using the supplied options.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configurationSection">The <see cref="IConfigurationSection"/> with the <see cref="CachingOptions"/> to be configured.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddTinyLogging(this IServiceCollection services, IConfigurationSection configurationSection) {
            return services
                .AddSingleton<ICachingSerializer, DefaultCachingSerializer>()
                .AddSingleton<ICachingAspect, DefaultCachingAspect>()
                .Configure<CachingOptions>(configurationSection);
        }
    }
}
