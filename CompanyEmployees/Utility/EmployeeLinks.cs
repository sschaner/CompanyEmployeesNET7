using CompanyEmployees.Contracts;
using CompanyEmployees.Entities.LinkModels;
using CompanyEmployees.Entities.Models;
using CompanyEmployees.Shared.DataTransferObjects;
using Microsoft.Net.Http.Headers;

namespace CompanyEmployees.Utility
{
    public class EmployeeLinks : IEmployeeLinks
    {
        /// <summary>
        /// The link generator
        /// </summary>
        private readonly LinkGenerator _linkGenerator;

        /// <summary>
        /// The data shaper
        /// </summary>
        private readonly IDataShaper<EmployeeDto> _dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeLinks"/> class.
        /// </summary>
        /// <param name="linkGenerator">The link generator.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public EmployeeLinks(LinkGenerator linkGenerator, IDataShaper<EmployeeDto> dataShaper)
        {
            _linkGenerator = linkGenerator;
            _dataShaper = dataShaper;
        }

        public LinkResponse TryGenerateLinks(IEnumerable<EmployeeDto> employeesDto, string fields, Guid companyId, HttpContext httpContext)
        {
            var shapedEmployees = ShapeData(employeesDto, fields);

            if (ShouldGenerateLinks(httpContext))
                return ReturnLinkedEmployees(employeesDto, fields, companyId, httpContext, shapedEmployees);

            return ReturnShapedEmployees(shapedEmployees);
        }

        /// <summary>
        /// Shapes the data.
        /// </summary>
        /// <param name="employeesDto">The employees dto.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        private List<Entity> ShapeData(IEnumerable<EmployeeDto> employeesDto, string fields) =>
            _dataShaper.ShapeData(employeesDto, fields)
            .Select(e => e.Entity)
            .ToList();

        /// <summary>
        /// Shoulds the generate links.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        private bool ShouldGenerateLinks(HttpContext httpContext)
        {
            var mediaType = (MediaTypeHeaderValue)httpContext.Items["AcceptHeaderMediaType"];

            return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Returns the shaped employees.
        /// </summary>
        /// <param name="shapedEmployees">The shaped employees.</param>
        /// <returns></returns>
        private LinkResponse ReturnShapedEmployees(List<Entity> shapedEmployees) =>
            new LinkResponse { ShapedEntities = shapedEmployees };

        /// <summary>
        /// Returns the linked employees.
        /// </summary>
        /// <param name="employeesDto">The employees dto.</param>
        /// <param name="fields">The fields.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="shapedEmployees">The shaped employees.</param>
        /// <returns></returns>
        private LinkResponse ReturnLinkedEmployees(IEnumerable<EmployeeDto> employeesDto, string fields, Guid companyId, HttpContext httpContext, List<Entity> shapedEmployees)
        {
            var employeeDtoList = employeesDto.ToList();

            for (int index = 0; index < employeeDtoList.Count(); index++)
            {
                var employeeLinks = CreateLinksForEmployee(httpContext, companyId, employeeDtoList[index].Id, fields);
                shapedEmployees[index].Add("Links", employeeLinks);
            }

            var employeeCollection = new LinkCollectionWrapper<Entity>(shapedEmployees);
            var linkedEmployees = CreateLinksForEmployees(httpContext, employeeCollection);

            return new LinkResponse { HasLinks = true, LinkedEntities = linkedEmployees};
        }

        /// <summary>
        /// Creates the links for employee.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        private List<Link> CreateLinksForEmployee(HttpContext httpContext, Guid companyId, Guid id, string fields = "")
        {
            var links = new List<Link>
            {
                new Link(_linkGenerator.GetUriByAction(httpContext, "GetEmployeeForCompany", values: new { companyId, id, fields}), "self", "GET"),
                new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteEmployeeForCompany", values: new { companyId, id }), "delete_employee", "DELETE"),
                new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateEmployeeForCompany", values: new { companyId, id }), "update_employee", "PUT"),
                new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateEmployeeForCompany", values: new { companyId, id}), "partially_update_employee", "PATCH")
            };

            return links;
        }

        /// <summary>
        /// Creates the links for employees.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="employeesWrapper">The employees wrapper.</param>
        /// <returns></returns>
        private LinkCollectionWrapper<Entity> CreateLinksForEmployees(HttpContext httpContext, LinkCollectionWrapper<Entity> employeesWrapper)
        {
            employeesWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetEmployeesForCompany", values: new { }), "self", "GET"));

            return employeesWrapper;
        }
    }
}
