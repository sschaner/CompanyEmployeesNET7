namespace CompanyEmployees.Entities.Exceptions
{
    public sealed class IdParametersBadRequestException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdParametersBadRequestException"/> class.
        /// </summary>
        public IdParametersBadRequestException()
            :base("Parameter ids is null")
        {

        }
    }
}
