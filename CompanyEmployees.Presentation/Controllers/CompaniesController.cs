namespace CompanyEmployees.Presentation.Controllers
{
    using CompanyEmployees.Presentation.ModelBinders;
    using CompanyEmployees.Service.Contracts;
    using CompanyEmployees.Shared.DataTransferObjects;
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
        [HttpGet("{id:guid}", Name = "CompanyById")]
        public IActionResult GetCompany(Guid id)
        {
            var company = _service.CompanyService.GetCompany(id, trackChanges: false);

            return Ok(company);
        }

        /// <summary>
        /// Gets the company collection.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        [HttpGet("collection/({ids})", Name = "CompanyCollection")]
        public IActionResult GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var companies = _service.CompanyService.GetByIds(ids, trackChanges: false);

            return Ok(companies);
        }

        /// <summary>
        /// Creates a company.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateCompany([FromBody] CompanyForCreationDto company)
        {
            if (company is null)
                return BadRequest("CompanyForCreationDto object is null.");

            var createdCompany = _service.CompanyService.CreateCompany(company);

            // Return the created company, using the GetCompany route.
            return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
        }

        /// <summary>
        /// Creates the company collection.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        [HttpPost("collection")]
        public IActionResult CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
        {
            var result = _service.CompanyService.CreateCompanyCollection(companyCollection);

            return CreatedAtRoute("CompanyCollection", new { result.ids }, result.companies);
        }
    }
}
