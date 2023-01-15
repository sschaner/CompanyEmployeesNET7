namespace CompanyEmployees.Service.Contracts
{
    using CompanyEmployees.Shared.DataTransferObjects;
    using CompanyEmployees.Shared.RequestFeatures;

    public interface ICompanyService
    {
        /// <summary>
        /// Gets all companies asynchronous.
        /// </summary>
        /// <param name="companyParameters">The company parameters.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        Task<(IEnumerable<CompanyDto> companies, MetaData metaData)> GetAllCompaniesAsync(CompanyParameters companyParameters, bool trackChanges);

        /// <summary>
        /// Gets the company asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        Task<CompanyDto> GetCompanyAsync(Guid companyId, bool trackChanges);

        /// <summary>
        /// Gets the by ids asynchronous.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);

        /// <summary>
        /// Creates the company asynchronous.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company);

        /// <summary>
        /// Creates the company collection asynchronous.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection);

        /// <summary>
        /// Deletes the company asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        Task DeleteCompanyAsync(Guid companyId, bool trackChanges);

        /// <summary>
        /// Updates the company asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="companyForUpdate">The company for update.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        Task UpdateCompanyAsync(Guid companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges);
    }
}
