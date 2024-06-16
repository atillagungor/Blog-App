using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.Hashing;

/// <summary>
/// Helper class for creating and verifying password hashes.
/// </summary>
public class HashingHelper
{
    /// <summary>
    /// Creates a hashed password and its associated salt.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <param name="passwordHash">Output parameter for the hashed password.</param>
    /// <param name="passwordSalt">Output parameter for the password salt.</param>
    public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    /// <summary>
    /// Verifies whether a password matches its hashed and salted version.
    /// </summary>
    /// <param name="password">The password to verify.</param>
    /// <param name="passwordHash">The hashed password to compare against.</param>
    /// <param name="passwordSalt">The salt associated with the hashed password.</param>
    /// <returns>True if the password matches the hashed password; otherwise, false.</returns>
    public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != passwordHash[i])
                {
                    return false;
                }
            }
        }
        return true;
    }
}