namespace CompanyEmployees.Shared.DataTransferObjects
{
    public record CompanyDto
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
        /// Gets the full address.
        /// </summary>
        /// <value>
        /// The full address.
        /// </value>
        public string? FullAddress { get; init; }
    }
}
