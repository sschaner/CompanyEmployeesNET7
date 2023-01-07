namespace CompanyEmployees.Contracts
{
    public interface IRepositoryManager
    {
        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        ICompanyRepository Company { get; }

        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        IEmployeeRepository Employee { get; }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();
    }
}
