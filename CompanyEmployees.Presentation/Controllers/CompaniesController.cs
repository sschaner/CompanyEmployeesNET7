namespace CompanyEmployees.Presentation.Controllers
{
    using CompanyEmployees.Service.Contracts;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly IServiceManager _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompaniesController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public CompaniesController(IServiceManager service) => _service = service;

        /// <summary>
        /// Gets all the companies.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCompanies()
        {
                var companies = _service.CompanyService.GetAllCompanies(trackChanges: false);

                return Ok(companies);
        }

        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public IActionResult GetCompany(Guid id)
        {
            var company = _service.CompanyService.GetCompany(id, trackChanges: false);

            return Ok(company);
        }
    }
}
