namespace CompanyEmployees.Shared.DataTransferObjects
{
    using System.ComponentModel.DataAnnotations;

    public record UserForAuthenticationDto
    {
        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; init; }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required(ErrorMessage = "Password name is required")]
        public string? Password { get; init; }
    }
}
