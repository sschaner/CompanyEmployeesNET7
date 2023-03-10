namespace CompanyEmployees.Contracts
{
    using CompanyEmployees.Entities.Models;
    using CompanyEmployees.Shared.RequestFeatures;

    public interface IEmployeeRepository
    {
        /// <summary>
        /// Gets the employees asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeParameters">The employee parameters.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges);

        /// <summary>
        /// Gets the employee asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);

        /// <summary>
        /// Creates the employee for company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employee">The employee.</param>
        void CreateEmployeeForCompany(Guid companyId, Employee employee);

        /// <summary>
        /// Deletes the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        void DeleteEmployee(Employee employee);
    }
}
