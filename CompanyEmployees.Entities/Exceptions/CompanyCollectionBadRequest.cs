namespace CompanyEmployees.Entities.Exceptions
{
    public sealed class CompanyCollectionBadRequest : BadRequestException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyCollectionBadRequest"/> class.
        /// </summary>
        public CompanyCollectionBadRequest()
            : base("Company collection sent from a client is null.")
        {

        }
    }
}
