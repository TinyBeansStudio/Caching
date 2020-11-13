namespace TinyBeans.Caching {

    /// <summary>
    /// Represents a type used by <see cref="ICachingAspect"/> to serialize and deserialize objects.
    /// </summary>
    public interface ICachingSerializer {

        /// <summary>
        /// Used to serialize an object to a string.
        /// </summary>
        /// <typeparam name="T">The type to serialize.</typeparam>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>A string representation of the object.</returns>
        string Serialize<T>(T obj);

        /// <summary>
        /// Used to deserialize a string back into an object.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="data">The string to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        T Deserialize<T>(string data);
    }
}
