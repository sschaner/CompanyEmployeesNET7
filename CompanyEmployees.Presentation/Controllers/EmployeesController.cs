namespace CompanyEmployees.Presentation.Controllers
{
    using CompanyEmployees.Service.Contracts;
    using CompanyEmployees.Shared.DataTransferObjects;
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
        public IActionResult GetEmployeesForCompany(Guid companyId)
        {
            var employees = _service.EmployeeService.GetEmployees(companyId, trackChanges: false);

            return Ok(employees);
        }

        /// <summary>
        /// Gets an employee for a company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:guid}", Name = "GetEmployeeForCompany")]
        public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var employee = _service.EmployeeService.GetEmployee(companyId, id, trackChanges: false);

            return Ok(employee);
        }

        /// <summary>
        /// Creates an employee for a company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
        {
            if (employee is null)
                return BadRequest("EmployeeForCreationDto object is null.");

            var employeeToReturn = _service.EmployeeService.CreateEmployeeForCompany(companyId, employee, trackChanges: false);

            return CreatedAtRoute("GetEmployeeForCompany", new { companyId, id = employeeToReturn.Id }, employeeToReturn);
        }
    }
}
