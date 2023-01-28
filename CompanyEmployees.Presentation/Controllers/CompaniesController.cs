namespace CompanyEmployees.Presentation.Controllers
{
    using CompanyEmployees.Presentation.ActionFilters;
    using CompanyEmployees.Presentation.ModelBinders;
    using CompanyEmployees.Service.Contracts;
    using CompanyEmployees.Shared.DataTransferObjects;
    using CompanyEmployees.Shared.RequestFeatures;
    using Microsoft.AspNetCore.Mvc;
    using System.Text.Json;

    [ApiVersion("1.0")]
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
        /// Gets the companies.
        /// </summary>
        /// <param name="companyParameters">The company parameters.</param>
        /// <returns></returns>
        [HttpGet(Name = "GetCompanies")]
        public async Task<IActionResult> GetCompanies([FromQuery] CompanyParameters companyParameters)
        {
            var pagedResult = await _service.CompanyService.GetAllCompaniesAsync(companyParameters, trackChanges: false);
            
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            
            return Ok(pagedResult.companies);
        }

        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:guid}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _service.CompanyService.GetCompanyAsync(id, trackChanges: false);

            return Ok(company);
        }

        /// <summary>
        /// Gets the company collection.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        [HttpGet("collection/({ids})", Name = "CompanyCollection")]
        public async Task<IActionResult> GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var companies = await _service.CompanyService.GetByIdsAsync(ids, trackChanges: false);

            return Ok(companies);
        }

        /// <summary>
        /// Creates a company.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        [HttpPost(Name = "CreateCompany")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
        {

            var createdCompany = await _service.CompanyService.CreateCompanyAsync(company);

            return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
        }

        /// <summary>
        /// Creates the company collection.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        [HttpPost("collection")]
        public async Task<IActionResult> CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
        {
            var result = await _service.CompanyService.CreateCompanyCollectionAsync(companyCollection);

            return CreatedAtRoute("CompanyCollection", new { result.ids }, result.companies);
        }

        /// <summary>
        /// Deletes the comany.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteComany(Guid id)
        {
            await _service.CompanyService.DeleteCompanyAsync(id, trackChanges: false);

            return NoContent();
        }

        /// <summary>
        /// Updates the company.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
        {
            await _service.CompanyService.UpdateCompanyAsync(id, company, trackChanges: true);

            return NoContent();
        }

        /// <summary>
        /// Gets the companies options.
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST, PUT, DELETE");

            return Ok();
        }
    }
}
