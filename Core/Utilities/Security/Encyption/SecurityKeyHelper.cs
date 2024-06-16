using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption;

/// <summary>
/// Helper class for creating security keys used in JWT authentication.
/// </summary>
public static class SecurityKeyHelper
{
    /// <summary>
    /// Creates a symmetric security key from the given string key.
    /// </summary>
    /// <param name="securityKey">The security key as a string.</param>
    /// <returns>A new instance of SymmetricSecurityKey.</returns>
    public static SecurityKey CreateSecurityKey(string securityKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
}