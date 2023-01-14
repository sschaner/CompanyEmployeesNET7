namespace CompanyEmployees.Repository
{
    using CompanyEmployees.Contracts;
    using CompanyEmployees.Entities.Models;

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
        /// Gets all companies.
        /// </summary>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToList();

        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        public Company GetCompany(Guid companyId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(companyId), trackChanges)
            .SingleOrDefault();

        /// <summary>
        /// Gets the by ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        public IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.Id), trackChanges);

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
