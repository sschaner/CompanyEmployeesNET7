namespace CompanyEmployees.Service.Contracts
{
    using CompanyEmployees.Entities.Models;
    using CompanyEmployees.Shared.DataTransferObjects;
    using CompanyEmployees.Shared.RequestFeatures;

    public interface IEmployeeService
    {
        /// <summary>
        /// Gets the employees asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeParameters">The employee parameters.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        Task<(IEnumerable<EmployeeDto> employees, MetaData metaData)> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges);

        /// <summary>
        /// Gets the employee asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);

        /// <summary>
        /// Creates the employee for company asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeForCreation">The employee for creation.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        Task<EmployeeDto> CreateEmployeeForCompanyAsync(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges);

        /// <summary>
        /// Deletes the employee for company asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges);

        /// <summary>
        /// Updates the employee for company asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="employeeForUpdate">The employee for update.</param>
        /// <param name="compTrackChanges">if set to <c>true</c> [comp track changes].</param>
        /// <param name="empTrackChanges">if set to <c>true</c> [emp track changes].</param>
        /// <returns></returns>
        Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid id, EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges);

        /// <summary>
        /// Gets the employee for patch asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="compTrackChanges">if set to <c>true</c> [comp track changes].</param>
        /// <param name="empTrackChanges">if set to <c>true</c> [emp track changes].</param>
        /// <returns></returns>
        Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync(Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges);

        /// <summary>
        /// Saves the changes for patch asynchronous.
        /// </summary>
        /// <param name="employeeToPatch">The employee to patch.</param>
        /// <param name="employeeEntity">The employee entity.</param>
        /// <returns></returns>
        Task SaveChangesForPatchAsync(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity);
    }
}
