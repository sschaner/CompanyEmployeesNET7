namespace CompanyEmployees.Repository.Extensions
{
    using CompanyEmployees.Entities.Models;

    public static class RepositoryEmployeeExtensions
    {
        /// <summary>
        /// Filters the employees.
        /// </summary>
        /// <param name="employees">The employees.</param>
        /// <param name="minAge">The minimum age.</param>
        /// <param name="maxAge">The maximum age.</param>
        /// <returns></returns>
        public static IQueryable<Employee> FilterEmployees(this IQueryable<Employee> employees, uint minAge, uint maxAge) =>
            employees.Where(e => (e.Age >= minAge && e.Age <= maxAge));

        /// <summary>
        /// Searches the specified search term.
        /// </summary>
        /// <param name="employees">The employees.</param>
        /// <param name="searchTerm">The search term.</param>
        /// <returns></returns>
        public static IQueryable<Employee> Search(this IQueryable<Employee> employees, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return employees;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return employees.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}
