namespace CompanyEmployees.Contracts
{
    using CompanyEmployees.Entities.Models;

    public interface ICompanyRepository
    {
        /// <summary>
        /// Gets all companies asynchronous.
        /// </summary>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges);

        /// <summary>
        /// Gets the company asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges);

        /// <summary>
        /// Gets the by ids asynchronous.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);

        /// <summary>
        /// Creates the company.
        /// </summary>
        /// <param name="company">The company.</param>
        void CreateCompany(Company company);

        /// <summary>
        /// Deletes the company.
        /// </summary>
        /// <param name="company">The company.</param>
        void DeleteCompany(Company company);
    }
}
