namespace CompanyEmployees.Repository
{
    using CompanyEmployees.Contracts;
    using CompanyEmployees.Entities.Models;
    using Microsoft.EntityFrameworkCore;

    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public CompanyRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        /// <summary>
        /// Gets all companies asynchronous.
        /// </summary>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

        /// <summary>
        /// Gets the company asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        public async Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(companyId), trackChanges)
            .SingleOrDefaultAsync();

        /// <summary>
        /// Gets the by ids asynchronous.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        public async Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.Id), trackChanges)
            .ToListAsync();

        /// <summary>
        /// Creates the company.
        /// </summary>
        /// <param name="company">The company.</param>
        public void CreateCompany(Company company) => Create(company);

        /// <summary>
        /// Deletes the company.
        /// </summary>
        /// <param name="company">The company.</param>
        public void DeleteCompany(Company company) => Delete(company);
    }
}
