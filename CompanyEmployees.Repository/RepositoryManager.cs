namespace CompanyEmployees.Repository
{
    using CompanyEmployees.Contracts;

    public sealed class RepositoryManager : IRepositoryManager
    {
        /// <summary>
        /// The repository context
        /// </summary>
        private readonly RepositoryContext _repositoryContext;

        /// <summary>
        /// The company respository
        /// </summary>
        private readonly Lazy<ICompanyRepository> _companyRespository;

        /// <summary>
        /// The employee repository
        /// </summary>
        private readonly Lazy<IEmployeeRepository> _employeeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryManager"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _companyRespository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
        }

        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public ICompanyRepository Company => _companyRespository.Value;

        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        public IEmployeeRepository Employee => _employeeRepository.Value;

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save() => _repositoryContext.SaveChanges();
    }
}
