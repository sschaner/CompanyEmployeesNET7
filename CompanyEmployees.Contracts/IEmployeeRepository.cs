namespace CompanyEmployees.Contracts
{
    using CompanyEmployees.Entities.Models;

    public interface IEmployeeRepository
    {
        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);

        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        Employee GetEmployee(Guid companyId, Guid id, bool trackChanges);
    }
}
