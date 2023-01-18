namespace CompanyEmployees.Contracts
{
    using CompanyEmployees.Entities.LinkModels;
    using CompanyEmployees.Shared.DataTransferObjects;
    using Microsoft.AspNetCore.Http;

    public interface IEmployeeLinks
    {
        /// <summary>
        /// Tries the generate links.
        /// </summary>
        /// <param name="employeesDto">The employees dto.</param>
        /// <param name="fields">The fields.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        LinkResponse TryGenerateLinks(IEnumerable<EmployeeDto> employeesDto, string fields, Guid companyId, HttpContext httpContext);
    }
}
