namespace CompanyEmployees.Entities.Exceptions
{
    public sealed class CollectionByIdsBadRequestException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionByIdsBadRequestException"/> class.
        /// </summary>
        public CollectionByIdsBadRequestException()
            :base("Collection count mismatch comparing to ids.")
        {

        }
    }
}
