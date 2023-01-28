namespace CompanyEmployees.Presentation.Controllers
{
    using CompanyEmployees.Entities.LinkModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    [Route("api")]
    [ApiController]
    public class RootController : ControllerBase
    {
        /// <summary>
        /// The link generator
        /// </summary>
        private readonly LinkGenerator _linkGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="RootController"/> class.
        /// </summary>
        /// <param name="linkGenerator">The link generator.</param>
        public RootController(LinkGenerator linkGenerator) => _linkGenerator = linkGenerator;

        /// <summary>
        /// Gets the root.
        /// </summary>
        /// <param name="mediaType">Type of the media.</param>
        /// <returns></returns>
        [HttpGet(Name = "GetRoot")]
        public IActionResult GetRoot([FromHeader(Name = "Accept")] string mediaType)
        {
            // Put this into an Accept header: application/vnd.codemaze.apiroot+json
            // Can also get XML back if you put this into the Accept header: application/vnd.codemaze.apiroot+xml

            if (mediaType.Contains("application/vnd.codemaze.apiroot"))
            {
                var list = new List<Link>
                {
                    new Link
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext, nameof(GetRoot), new {}),
                        Rel = "self",
                        Method = "GET",
                    },
                    new Link
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext, "GetCompanies", new {}),
                        Rel = "companies",
                        Method = "GET",
                    },
                    new Link
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext, "CreateCompany", new {}),
                        Rel = "create_company",
                        Method = "POST",
                    }
                };

                return Ok(list);
            }

            return NoContent();
        }
    }
}
