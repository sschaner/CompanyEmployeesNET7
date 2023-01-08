namespace CompanyEmployees.Shared.DataTransferObjects
{
    public record CompanyForCreationDto(string Name, string Address, string Country);

    // This allows the creation of employees when creating a company.
    //public record CompanyForCreationDto(string Name, string Address, string Country, IEnumerable<EmployeeForCreationDto> Employees);
}
