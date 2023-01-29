namespace CompanyEmployees.Service.Contracts
{
    public interface IServiceManager
    {
        /// <summary>
        /// Gets the company service.
        /// </summary>
        /// <value>
        /// The company service.
        /// </value>
        ICompanyService CompanyService { get; }

        /// <summary>
        /// Gets the employee service.
        /// </summary>
        /// <value>
        /// The employee service.
        /// </value>
        IEmployeeService EmployeeService { get; }

        /// <summary>
        /// Gets the authentication service.
        /// </summary>
        /// <value>
        /// The authentication service.
        /// </value>
        IAuthenticationService AuthenticationService { get; }
    }
}
