namespace CompanyEmployees.Shared.RequestFeatures
{
    public class EmployeeParameters : RequestParameters
    {
        // uint means "unsigned integer"
        // Unsigned integers only contain positive numbers (or zero)
        // This means the default for uint is 0

        public EmployeeParameters() => OrderBy = "name";

        /// <summary>
        /// Gets or sets the minimum age.
        /// </summary>
        /// <value>
        /// The minimum age.
        /// </value>
        public uint MinAge { get; set; }

        /// <summary>
        /// Gets or sets the maximum age.
        /// </summary>
        /// <value>
        /// The maximum age.
        /// </value>
        public uint MaxAge { get; set; } = int.MaxValue;

        /// <summary>
        /// Gets a value indicating whether [valid age range].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [valid age range]; otherwise, <c>false</c>.
        /// </value>
        public bool ValidAgeRange => MaxAge > MinAge;

        /// <summary>
        /// Gets or sets the search term.
        /// </summary>
        /// <value>
        /// The search term.
        /// </value>
        public string? SearchTerm { get; set; }
    }
}
