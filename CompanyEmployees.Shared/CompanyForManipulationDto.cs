namespace CompanyEmployees.Shared
{
    using System.ComponentModel.DataAnnotations;

    public abstract record CompanyForManipulationDto
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; init; }

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [Required(ErrorMessage = "Company address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters.")]
        public string? Address { get; init; }

        /// <summary>
        /// Gets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string? Country { get; init; }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <value>
        /// The employees.
        /// </value>
        /// This allows the creation of employees when creating a company.
        //public IEnumerable<EmployeeForCreationDto>? Employees { get; init; }
    }
}
