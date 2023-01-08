namespace CompanyEmployees.Shared.DataTransferObjects
{
    public record EmployeeDto
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; init; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string? Name { get; init; }

        /// <summary>
        /// Gets the age.
        /// </summary>
        /// <value>
        /// The age.
        /// </value>
        public int Age { get; init; }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public string? Position { get; init; }
    }
}
