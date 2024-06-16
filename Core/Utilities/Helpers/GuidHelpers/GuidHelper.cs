using System;

namespace Core.Utilities.Helpers.GuidHelpers
{
    /// <summary>
    /// Helper class for generating and manipulating GUIDs.
    /// </summary>
    public static class GuidHelper
    {
        /// <summary>
        /// Generates a new GUID as a string.
        /// </summary>
        /// <returns>A new GUID string.</returns>
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Generates a new sequential GUID as a string.
        /// </summary>
        /// <returns>A new sequential GUID string.</returns>
        public static string CreateSequentialGuid()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}