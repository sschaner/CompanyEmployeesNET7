namespace CompanyEmployees.Service
{
    using AutoMapper;
    using CompanyEmployees.Contracts;
    using CompanyEmployees.Entities.Models;
    using CompanyEmployees.Service.Contracts;
    using CompanyEmployees.Shared.DataTransferObjects;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;

    public sealed class ServiceManager : IServiceManager
    {
        /// <summary>
        /// The company service
        /// </summary>
        private readonly Lazy<ICompanyService> _companyService;

        /// <summary>
        /// The employee service
        /// </summary>
        private readonly Lazy<IEmployeeService> _employeeService;

        /// <summary>
        /// The authentication service
        /// </summary>
        private readonly Lazy<IAuthenticationService> _authenticationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceManager" /> class.
        /// </summary>
        /// <param name="repositoryManager">The repository manager.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="employeeLinks">The employee links.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="configuration">The configuration.</param>
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, IEmployeeLinks employeeLinks, UserManager<User> userManager, IConfiguration configuration)
        {
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, logger, mapper));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper, employeeLinks));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
        }

        /// <summary>
        /// Gets the company service.
        /// </summary>
        /// <value>
        /// The company service.
        /// </value>
        public ICompanyService CompanyService => _companyService.Value;

        /// <summary>
        /// Gets the employee service.
        /// </summary>
        /// <value>
        /// The employee service.
        /// </value>
        public IEmployeeService EmployeeService => _employeeService.Value;

        /// <summary>
        /// Gets the authentication service.
        /// </summary>
        /// <value>
        /// The authentication service.
        /// </value>
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
