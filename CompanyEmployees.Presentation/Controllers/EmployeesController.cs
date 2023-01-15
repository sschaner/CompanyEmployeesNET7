namespace CompanyEmployees.Presentation.Controllers
{
    using CompanyEmployees.Presentation.ActionFilters;
    using CompanyEmployees.Service.Contracts;
    using CompanyEmployees.Shared.DataTransferObjects;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly IServiceManager _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public EmployeesController(IServiceManager service) => _service = service;

        /// <summary>
        /// Gets the employees for a company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetEmployeesForCompany(Guid companyId)
        {
            var employees = await _service.EmployeeService.GetEmployeesAsync(companyId, trackChanges: false);

            return Ok(employees);
        }

        /// <summary>
        /// Gets an employee for a company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:guid}", Name = "GetEmployeeForCompany")]
        public async Task<IActionResult> GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var employee = await _service.EmployeeService.GetEmployeeAsync(companyId, id, trackChanges: false);

            return Ok(employee);
        }

        /// <summary>
        /// Creates an employee for a company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
        {
            var employeeToReturn = await _service.EmployeeService.CreateEmployeeForCompanyAsync(companyId, employee, trackChanges: false);

            return CreatedAtRoute("GetEmployeeForCompany", new { companyId, id = employeeToReturn.Id }, employeeToReturn);
        }

        /// <summary>
        /// Deletes the employee for company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployeeForCompany(Guid companyId, Guid id)
        {
            await _service.EmployeeService.DeleteEmployeeForCompanyAsync(companyId, id, trackChanges: false);

            return NoContent();
        }

        /// <summary>
        /// Updates the employee for company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] EmployeeForUpdateDto employee)
        {
            await _service.EmployeeService.UpdateEmployeeForCompanyAsync(companyId, id, employee, compTrackChanges: false, empTrackChanges: true);

            return NoContent();
        }

        /// <summary>
        /// Partially updates the employee for company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="patchDoc">The patch document.</param>
        /// <returns></returns>
        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] JsonPatchDocument<EmployeeForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = await _service.EmployeeService.GetEmployeeForPatchAsync(companyId, id, compTrackChanges: false, empTrackChanges: true);

            patchDoc.ApplyTo(result.employeeToPatch, ModelState);

            TryValidateModel(result.employeeToPatch);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.EmployeeService.SaveChangesForPatchAsync(result.employeeToPatch, result.employeeEntity);

            return NoContent();
        }
    }
}
