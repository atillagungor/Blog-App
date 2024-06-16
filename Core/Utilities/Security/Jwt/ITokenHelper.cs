using Core.Entities;

namespace Core.Utilities.Security.Jwt
{
    /// <summary>
    /// Interface for token creation operations.
    /// </summary>
    public interface ITokenHelper
    {
        /// <summary>
        /// Creates an access token for the given user with specified operation claims.
        /// </summary>
        /// <param name="user">The user for whom the token is created.</param>
        /// <param name="operationClaims">List of operation claims (permissions).</param>
        /// <returns>An AccessToken object representing the generated token.</returns>
        AccessToken CreateToken(IUser user, List<IOperationClaim> operationClaims);
    }
}