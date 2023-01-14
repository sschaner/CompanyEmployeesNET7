namespace CompanyEmployees.Service.Contracts
{
    using CompanyEmployees.Entities.Models;
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

        /// <summary>
        /// Deletes the employee for company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        void DeleteEmployeeForCompany(Guid companyId, Guid id, bool trackChanges);

        /// <summary>
        /// Updates the employee for company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="employeeForUpdate">The employee for update.</param>
        /// <param name="compTrackChanges">if set to <c>true</c> [comp track changes].</param>
        /// <param name="empTrackChanges">if set to <c>true</c> [emp track changes].</param>
        void UpdateEmployeeForCompany(Guid companyId, Guid id, EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges);

        /// <summary>
        /// Gets the employee for patch.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="compTrackChanges">if set to <c>true</c> [comp track changes].</param>
        /// <param name="empTrackChanges">if set to <c>true</c> [emp track changes].</param>
        /// <returns></returns>
        (EmployeeForUpdateDto employeeToPatch, Employee employeeEntity) GetEmployeeForPatch(Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges);

        /// <summary>
        /// Saves the changes for patch.
        /// </summary>
        /// <param name="employeeToPatch">The employee to patch.</param>
        /// <param name="employeeEntity">The employee entity.</param>
        void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity);
    }
}
