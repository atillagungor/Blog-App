using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    /// <summary>
    /// Helper class for creating signing credentials used in JWT authentication.
    /// </summary>
    public static class SigningCredentialsHelper
    {
        /// <summary>
        /// Creates signing credentials using the provided security key.
        /// </summary>
        /// <param name="securityKey">The security key used for signing.</param>
        /// <returns>A new instance of SigningCredentials.</returns>
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}