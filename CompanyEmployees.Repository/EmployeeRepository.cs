namespace CompanyEmployees.Repository
{
    using CompanyEmployees.Contracts;
    using CompanyEmployees.Entities.Models;
    using CompanyEmployees.Shared.RequestFeatures;
    using Microsoft.EntityFrameworkCore;

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

        /// <summary>
        /// Gets the employees asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeParameters">The employee parameters.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges)
        {
            var employees = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
                .OrderBy(e => e.Name)
                .ToListAsync();

            return PagedList<Employee>
                .ToPagedList(employees, employeeParameters.PageNumber, employeeParameters.PageSize);
        }

        /// <summary>
        /// Gets the employee asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges) =>
            await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        /// <summary>
        /// Creates the employee for company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employee">The employee.</param>
        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        /// <summary>
        /// Deletes the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void DeleteEmployee(Employee employee) => Delete(employee);
    }
}
