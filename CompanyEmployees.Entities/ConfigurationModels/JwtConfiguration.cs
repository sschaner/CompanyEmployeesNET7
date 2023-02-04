namespace CompanyEmployees.Entities.ConfigurationModels
{
    public class JwtConfiguration
    {
        /// <summary>
        /// Gets or sets the section.
        /// </summary>
        /// <value>
        /// The section.
        /// </value>
        public string Section { get; set; } = "JwtSettings";

        /// <summary>
        /// Gets or sets the valid issuer.
        /// </summary>
        /// <value>
        /// The valid issuer.
        /// </value>
        public string? ValidIssuer { get; set; }

        /// <summary>
        /// Gets or sets the valid audience.
        /// </summary>
        /// <value>
        /// The valid audience.
        /// </value>
        public string? ValidAudience { get; set; }

        /// <summary>
        /// Gets or sets the expires.
        /// </summary>
        /// <value>
        /// The expires.
        /// </value>
        public string? Expires { get; set; }
    }
}
