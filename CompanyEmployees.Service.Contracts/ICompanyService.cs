namespace CompanyEmployees.Service.Contracts
{
    using CompanyEmployees.Shared.DataTransferObjects;

    public interface ICompanyService
    {
        /// <summary>
        /// Gets all companies.
        /// </summary>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);

        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        CompanyDto GetCompany(Guid companyId, bool trackChanges);

        /// <summary>
        /// Gets the by ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        IEnumerable<CompanyDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);

        /// <summary>
        /// Creates the company.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        CompanyDto CreateCompany(CompanyForCreationDto company);

        /// <summary>
        /// Creates the company collection.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        (IEnumerable<CompanyDto> companies, string ids) CreateCompanyCollection(IEnumerable<CompanyForCreationDto> companyCollection);

        /// <summary>
        /// Deletes the company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        void DeleteCompany(Guid companyId, bool trackChanges);
    }
}
