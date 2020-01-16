using System;

namespace StringManipulation
{
    /// <summary>
    /// Greeting class.
    /// </summary>
    public static class Greeting
    {
        /// <summary>
        /// Method that creates the greeting string.
        /// </summary>
        /// <param name="userName">Name of user.</param>
        /// <returns>Greeting string with user.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the userName is null.</exception>
        /// <example> SayHello("John") = "Hello, John!".</example>
        public static string SayHello(string userName)
        {
            if (userName is null)
            {
                throw new ArgumentNullException(nameof(userName), "User name cannot be null");
            }

            return userName == string.Empty ? "Hello, unknown!" : $"Hello, {userName}!";
        }
    }
}