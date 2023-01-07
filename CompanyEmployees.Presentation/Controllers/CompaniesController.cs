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
            try
            {
                var companies = _service.CompanyService.GetAllCompanies(trackChanges: false);

                return Ok(companies);
            }
            catch
            {
                return StatusCode(500, "Internal servor error");
            }
        }
    }
}
