using Core.Entities;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Utilities.Security.Jwt
{
    /// <summary>
    /// Helper class for JWT token creation and management.
    /// </summary>
    public class JwtHelper : ITokenHelper
    {
        private readonly IConfiguration _configuration;
        private readonly TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        /// <summary>
        /// Initializes a new instance of the JwtHelper class.
        /// </summary>
        /// <param name="configuration">Configuration instance for retrieving token options.</param>
        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        /// <summary>
        /// Creates an access token for the given user with specified operation claims.
        /// </summary>
        /// <param name="user">The user for whom the token is created.</param>
        /// <param name="operationClaims">List of operation claims (permissions).</param>
        /// <returns>An AccessToken object representing the generated token.</returns>
        public AccessToken CreateToken(IUser user, List<IOperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        /// <summary>
        /// Creates a JWT security token with specified options, user information, and signing credentials.
        /// </summary>
        /// <param name="tokenOptions">Token options for configuring token properties.</param>
        /// <param name="user">The user for whom the token is created.</param>
        /// <param name="signingCredentials">Signing credentials used for token signature.</param>
        /// <param name="operationClaims">List of operation claims (permissions).</param>
        /// <returns>A JwtSecurityToken instance representing the JWT token.</returns>
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, IUser user,
            SigningCredentials signingCredentials, List<IOperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );

            return jwt;
        }

        /// <summary>
        /// Sets the claims for the JWT token based on the user and operation claims.
        /// </summary>
        /// <param name="user">The user for whom the claims are set.</param>
        /// <param name="operationClaims">List of operation claims (permissions).</param>
        /// <returns>A list of claims for the JWT token.</returns>
        private IEnumerable<Claim> SetClaims(IUser user, List<IOperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}