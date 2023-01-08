namespace CompanyEmployees.Service.Contracts
{
    using CompanyEmployees.Shared.DataTransferObjects;

    public interface IEmployeeService
    {
        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges);

        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackChanges);

        /// <summary>
        /// Creates the employee for company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeForCreation">The employee for creation.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges);
    }
}
