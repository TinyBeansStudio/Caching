using System.Text.Json;

namespace TinyBeans.Caching.Defaults {

    /// <summary>
    /// Represents a type used by <see cref="ICachingAspect{T}"/> to serialize and deserialize objects.
    /// </summary>
    public class DefaultCachingSerializer : ICachingSerializer {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions() {
            IgnoreNullValues = true,
            IgnoreReadOnlyProperties = true
        };

        /// <summary>
        /// Used to serialize an object to a string.
        /// </summary>
        /// <typeparam name="T">The type to serialize.</typeparam>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>A string representation of the object.</returns>
        public string Serialize<T>(T obj) {
            return JsonSerializer.Serialize(obj, _options);
        }

        /// <summary>
        /// Used to deserialize a string back into an object.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="data">The string to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public T Deserialize<T>(string data) {
            return JsonSerializer.Deserialize<T>(data, _options);
        }
    }
}
