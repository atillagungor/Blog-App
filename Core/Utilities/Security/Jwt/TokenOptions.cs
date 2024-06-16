namespace Core.Utilities.Security.Jwt
{
    /// <summary>
    /// Options for configuring JWT settings.
    /// </summary>
    public class TokenOptions
    {
        /// <summary>
        /// Gets or sets the audience of the JWT.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Gets or sets the issuer of the JWT.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Gets or sets the expiration time of the access token in minutes.
        /// </summary>
        public int AccessTokenExpiration { get; set; }

        /// <summary>
        /// Gets or sets the security key used to create the JWT signature.
        /// </summary>
        public string SecurityKey { get; set; }
    }
}