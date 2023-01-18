namespace CompanyEmployees.Service
{
    using AutoMapper;
    using CompanyEmployees.Contracts;
    using CompanyEmployees.Service.Contracts;
    using CompanyEmployees.Shared.DataTransferObjects;

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
        /// Initializes a new instance of the <see cref="ServiceManager" /> class.
        /// </summary>
        /// <param name="repositoryManager">The repository manager.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="employeeLinks">The employee links.</param>
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, IEmployeeLinks employeeLinks)
        {
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, logger, mapper));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper, employeeLinks));
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
    }
}
