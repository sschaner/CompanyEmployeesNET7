namespace CompanyEmployees.Service
{
    using AutoMapper;
    using CompanyEmployees.Contracts;
    using CompanyEmployees.Entities.Exceptions;
    using CompanyEmployees.Entities.Models;
    using CompanyEmployees.Service.Contracts;
    using CompanyEmployees.Shared.DataTransferObjects;
    using CompanyEmployees.Shared.RequestFeatures;
    using System.ComponentModel.Design;

    internal sealed class CompanyService : ICompanyService
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
        /// Initializes a new instance of the <see cref="CompanyService" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="mapper">The mapper.</param>
        public CompanyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all companies asynchronous.
        /// </summary>
        /// <param name="companyParameters">The company parameters.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        public async Task<(IEnumerable<CompanyDto> companies, MetaData metaData)> GetAllCompaniesAsync(CompanyParameters companyParameters, bool trackChanges)
        {
                var companiesWithMetaData =  await _repository.Company.GetAllCompaniesAsync(companyParameters, trackChanges);
                var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companiesWithMetaData);

                return (companies: companiesDto, metaData: companiesWithMetaData.MetaData);
        }

        /// <summary>
        /// Gets the company asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.CompanyNotFoundException"></exception>
        public async Task<CompanyDto> GetCompanyAsync(Guid id, bool trackChanges)
        {
            var company = await GetCompanyAndCheckIfItExists(id, trackChanges);

            var companyDto = _mapper.Map<CompanyDto>(company);

            return companyDto;
        }

        /// <summary>
        /// Gets the by ids asynchronous.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.IdParametersBadRequestException"></exception>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.CollectionByIdsBadRequestException"></exception>
        public async Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var companyEntities = await _repository.Company.GetByIdsAsync(ids, trackChanges);
            if (ids.Count() != companyEntities.Count())
                throw new CollectionByIdsBadRequestException();

            var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);

            return companiesToReturn;
        }

        /// <summary>
        /// Creates the company asynchronous.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        public async Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company)
        {
            var companyEntity = _mapper.Map<Company>(company);

            _repository.Company.CreateCompany(companyEntity);
            await _repository.SaveAsync();

            var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);

            return companyToReturn;
        }

        /// <summary>
        /// Creates the company collection asynchronous.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.CompanyCollectionBadRequest"></exception>
        public async Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync (IEnumerable<CompanyForCreationDto> companyCollection)
        {
            if (companyCollection is null)
                throw new CompanyCollectionBadRequest();

            var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);
            foreach (var company in companyEntities)
            {
                _repository.Company.CreateCompany(company);
            }

            await _repository.SaveAsync();

            var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));

            return (companies: companyCollectionToReturn, ids: ids);
        }

        /// <summary>
        /// Deletes the company asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.CompanyNotFoundException"></exception>
        public async Task DeleteCompanyAsync(Guid companyId, bool trackChanges)
        {
            var company = await GetCompanyAndCheckIfItExists(companyId, trackChanges);

            _repository.Company.DeleteCompany(company);
            await _repository.SaveAsync();
        }

        /// <summary>
        /// Updates the company asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="companyForUpdate">The company for update.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.CompanyNotFoundException"></exception>
        public async Task UpdateCompanyAsync(Guid companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges)
        {
            var company = await GetCompanyAndCheckIfItExists(companyId, trackChanges);

            _mapper.Map(companyForUpdate, company);
            await _repository.SaveAsync();
        }

        /// <summary>
        /// Gets the company and check if it exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        /// <exception cref="CompanyEmployees.Entities.Exceptions.CompanyNotFoundException"></exception>
        private async Task<Company> GetCompanyAndCheckIfItExists(Guid id, bool trackChanges)
        {
            var company = await _repository.Company.GetCompanyAsync(id, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(id);

            return company;
        }
    }
}
