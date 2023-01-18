namespace CompanyEmployees.Entities.LinkModels
{
    using CompanyEmployees.Shared.RequestFeatures;
    using Microsoft.AspNetCore.Http;

    public record LinkParameters(EmployeeParameters EmployeeParameters, HttpContext Context);
}
