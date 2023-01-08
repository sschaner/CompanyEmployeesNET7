namespace CompanyEmployees.Entities.Exceptions
{
    public abstract class BadRequestException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        protected BadRequestException(string message)
            : base(message)
        {

        }
    }
}
