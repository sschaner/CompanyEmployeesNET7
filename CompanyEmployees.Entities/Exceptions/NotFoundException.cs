namespace CompanyEmployees.Entities.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        protected NotFoundException(string message)
            : base(message)
        {

        }
    }
}
