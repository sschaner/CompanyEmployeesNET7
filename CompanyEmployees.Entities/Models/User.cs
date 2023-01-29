namespace CompanyEmployees.Entities.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the refresh token.
        /// </summary>
        /// <value>
        /// The refresh token.
        /// </value>
        public string? RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the refresh token expiry time.
        /// </summary>
        /// <value>
        /// The refresh token expiry time.
        /// </value>
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
