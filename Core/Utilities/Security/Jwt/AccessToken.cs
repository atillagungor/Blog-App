namespace Core.Utilities.Security.Jwt
{
    /// <summary>
    /// Represents an access token used in authentication.
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// Gets or sets the token string.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the expiration date and time of the token.
        /// </summary>
        public DateTime Expiration { get; set; }
    }
}