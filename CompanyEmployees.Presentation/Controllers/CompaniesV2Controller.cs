namespace CompanyEmployees.Presentation.Controllers
{
    using CompanyEmployees.Service.Contracts;
    using CompanyEmployees.Shared.RequestFeatures;
    using Microsoft.AspNetCore.Mvc;
    using System.Text.Json;

    //[ApiVersion("2.0", Deprecated = true)]
    [Route("api/companies")]
    //[Route("api/{v:apiversion}/companies")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class CompaniesV2Controller : ControllerBase
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly IServiceManager _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompaniesV2Controller"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public CompaniesV2Controller(IServiceManager service) => _service = service;

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
    }
}
