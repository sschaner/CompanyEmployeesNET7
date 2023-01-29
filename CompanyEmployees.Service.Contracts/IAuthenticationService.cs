namespace CompanyEmployees.Service.Contracts
{
    using CompanyEmployees.Shared.DataTransferObjects;
    using Microsoft.AspNetCore.Identity;

    public interface IAuthenticationService
    {
        /// <summary>
        /// Registers the user.
        /// Executes the registration logic and returns the identity result to the caller
        /// </summary>
        /// <param name="userForRegistration">The user for registration.</param>
        /// <returns></returns>
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);

        /// <summary>
        /// Validates the user.
        /// </summary>
        /// <param name="userForAuth">The user for authentication.</param>
        /// <returns></returns>
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);

        /// <summary>
        /// Creates the token.
        /// </summary>
        /// <returns></returns>
        Task<string> CreateToken();
    }
}
