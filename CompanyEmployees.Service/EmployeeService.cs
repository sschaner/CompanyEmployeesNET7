namespace CompanyEmployees.Service
{
    using AutoMapper;
    using CompanyEmployees.Contracts;
    using CompanyEmployees.Entities.Exceptions;
    using CompanyEmployees.Entities.LinkModels;
    using CompanyEmployees.Entities.Models;
    using CompanyEmployees.Service.Contracts;
    using CompanyEmployees.Shared.DataTransferObjects;
    using CompanyEmployees.Shared.RequestFeatures;
    using System.Dynamic;

    internal sealed class EmployeeService : IEmployeeService
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRepositoryManager _repository;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILoggerManager _logger;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The employee links
        /// </summary>
        private readonly IEmployeeLinks _employeeLinks;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyService" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="employeeLinks">The employee links.</param>
        public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IEmployeeLinks employeeLinks)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _employeeLinks = employeeLinks;
        }

        /// <summary>
        /// Gets the employees asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="linkParameters">The link parameters.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.MaxAgeRangeBadRequestException"></exception>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.CompanyNotFoundException"></exception>
        public async Task<(LinkResponse linkResponse , MetaData metaData)> GetEmployeesAsync(Guid companyId, LinkParameters linkParameters, bool trackChanges)
        {
            if (!linkParameters.EmployeeParameters.ValidAgeRange)
                throw new MaxAgeRangeBadRequestException();

            await CheckIfCompanyExists(companyId, trackChanges);

            var employeesWithMetaData = await _repository.Employee.GetEmployeesAsync(companyId, linkParameters.EmployeeParameters, trackChanges);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesWithMetaData);
            var links = _employeeLinks.TryGenerateLinks(employeesDto, linkParameters.EmployeeParameters.Fields, companyId, linkParameters.Context);

            return (linkResponse: links, metaData: employeesWithMetaData.MetaData);
        }

        /// <summary>
        /// Gets the employee asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.CompanyNotFoundException"></exception>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.EmployeeNotFoundException"></exception>
        public async Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);

            var employeeDb = await GetEmployeeForCompanyAndCheckIfItExists(companyId, id, trackChanges);

            var employee = _mapper.Map<EmployeeDto>(employeeDb);

            return employee;
        }

        /// <summary>
        /// Creates the employee for company asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeForCreation">The employee for creation.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.CompanyNotFoundException"></exception>
        public async Task<EmployeeDto> CreateEmployeeForCompanyAsync(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);

            var employeeEntity = _mapper.Map<Employee>(employeeForCreation);

            _repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
            await _repository.SaveAsync();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);

            return employeeToReturn;
        }

        /// <summary>
        /// Deletes the employee for company asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.CompanyNotFoundException"></exception>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.EmployeeNotFoundException"></exception>
        public async Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);

            var employeeDb = await GetEmployeeForCompanyAndCheckIfItExists(companyId, id, trackChanges);

            _repository.Employee.DeleteEmployee(employeeDb);
            await _repository.SaveAsync();
        }

        /// <summary>
        /// Updates the employee for company asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="employeeForUpdate">The employee for update.</param>
        /// <param name="compTrackChanges">if set to <c>true</c> [comp track changes].</param>
        /// <param name="empTrackChanges">if set to <c>true</c> [emp track changes].</param>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.CompanyNotFoundException"></exception>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.EmployeeNotFoundException"></exception>
        public async Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid id, EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges)
        {
            await CheckIfCompanyExists(companyId, compTrackChanges);

            var employeeDb = await GetEmployeeForCompanyAndCheckIfItExists(companyId, id, empTrackChanges);

            _mapper.Map(employeeForUpdate, employeeDb);
            await _repository.SaveAsync();
        }

        /// <summary>
        /// Gets the employee for patch asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="compTrackChanges">if set to <c>true</c> [comp track changes].</param>
        /// <param name="empTrackChanges">if set to <c>true</c> [emp track changes].</param>
        /// <returns></returns>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.CompanyNotFoundException"></exception>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.EmployeeNotFoundException"></exception>
        public async Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync(Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges)
        {
            await CheckIfCompanyExists(companyId, compTrackChanges);

            var employeeDb = await GetEmployeeForCompanyAndCheckIfItExists(companyId, id, empTrackChanges);

            var employeeToPatch = _mapper.Map<EmployeeForUpdateDto>(employeeDb);

            return (employeeToPatch: employeeToPatch, employeeEntity: employeeDb);
        }

        /// <summary>
        /// Saves the changes for patch asynchronous.
        /// </summary>
        /// <param name="employeeToPatch">The employee to patch.</param>
        /// <param name="employeeEntity">The employee entity.</param>
        public async Task SaveChangesForPatchAsync(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)
        {
            _mapper.Map(employeeToPatch, employeeEntity);

            await _repository.SaveAsync();
        }

        /// <summary>
        /// Checks if company exists.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.CompanyNotFoundException"></exception>
        private async Task CheckIfCompanyExists(Guid companyId, bool trackChanges)
        {
            var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);
        }

        /// <summary>
        /// Gets the employee for company and check if it exists.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.EmployeeNotFoundException"></exception>
        private async Task<Employee> GetEmployeeForCompanyAndCheckIfItExists(Guid companyId, Guid id, bool trackChanges)
        {
            var employeeDb = await _repository.Employee.GetEmployeeAsync(companyId, id, trackChanges);
            if (employeeDb is null)
                throw new EmployeeNotFoundException(id);

            return employeeDb;
        }
    }
}
