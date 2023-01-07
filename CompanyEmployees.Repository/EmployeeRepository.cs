namespace CompanyEmployees.Repository
{
    using CompanyEmployees.Contracts;
    using CompanyEmployees.Entities.Models;

    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public EmployeeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
