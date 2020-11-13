using System;
using System.Threading.Tasks;

namespace TinyBeans.Caching {

    /// <summary>
    /// Represents a type used to wrap and cache method return values.
    /// </summary>
    public interface ICachingAspect {

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="R">The result type.</typeparam>
        /// <param name="method">The method to invoke.</param>
        /// <returns>The result of the invoked method.</returns>
        R Invoke<R>(Func<R> method);

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="P1">The type of the first parameter to pass to the method.</typeparam>
        /// <typeparam name="R">The result type.</typeparam>
        /// <param name="method">The method to invoke.</param>
        /// <param name="p1">The first parameter to pass to the method.</param>
        /// <returns>The result of the invoked method.</returns>
        R Invoke<P1, R>(Func<P1, R> method, P1 p1);

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
        R Invoke<P1, P2, R>(Func<P1, P2, R> method, P1 p1, P2 p2);

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
        R Invoke<P1, P2, P3, R>(Func<P1, P2, P3, R> method, P1 p1, P2 p2, P3 p3);

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
        R Invoke<P1, P2, P3, P4, R>(Func<P1, P2, P3, P4, R> method, P1 p1, P2 p2, P3 p3, P4 p4);

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
        R Invoke<P1, P2, P3, P4, P5, R>(Func<P1, P2, P3, P4, P5, R> method, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5);

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="R">The result type of the <see cref="Task"/>.</typeparam>
        /// <param name="method">The method to invoke.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task<R> InvokeAsync<R>(Func<Task<R>> method);

        /// <summary>
        /// Invokes the supplied method and caches the result.
        /// </summary>
        /// <typeparam name="P1">The type of the first parameter to pass to the method.</typeparam>
        /// <typeparam name="R">The result type of the <see cref="Task"/>.</typeparam>
        /// <param name="method">The method to invoke.</param>
        /// <param name="p1">The first parameter to pass to the method.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task<R> InvokeAsync<P1, R>(Func<P1, Task<R>> method, P1 p1);

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
        Task<R> InvokeAsync<P1, P2, R>(Func<P1, P2, Task<R>> method, P1 p1, P2 p2);

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
        Task<R> InvokeAsync<P1, P2, P3, R>(Func<P1, P2, P3, Task<R>> method, P1 p1, P2 p2, P3 p3);

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
        Task<R> InvokeAsync<P1, P2, P3, P4, R>(Func<P1, P2, P3, P4, Task<R>> method, P1 p1, P2 p2, P3 p3, P4 p4);

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
        Task<R> InvokeAsync<P1, P2, P3, P4, P5, R>(Func<P1, P2, P3, P4, P5, Task<R>> method, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5);
    }
}
