namespace CompanyEmployees.Contracts
{
    using CompanyEmployees.Entities.Models;

    public interface ICompanyRepository
    {
        /// <summary>
        /// Gets all companies.
        /// </summary>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        IEnumerable<Company> GetAllCompanies(bool trackChanges);

        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        Company GetCompany(Guid companyId, bool trackChanges);
    }
}
