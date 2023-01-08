namespace CompanyEmployees
{
    using AutoMapper;
    using CompanyEmployees.Entities.Models;
    using CompanyEmployees.Shared.DataTransferObjects;

    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(c => c.FullAddress,
                opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<Employee, EmployeeDto>();

            CreateMap<CompanyForCreationDto, Company>();

            CreateMap<EmployeeForCreationDto, Employee>();
        }
    }
}
