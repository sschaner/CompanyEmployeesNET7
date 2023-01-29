namespace CompanyEmployees.Entities.Exceptions
{
    public sealed class RefreshTokenBadRequest : BadRequestException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RefreshTokenBadRequest"/> class.
        /// </summary>
        public RefreshTokenBadRequest()
            : base("Invalid client request. The tokenDto has some invalid values.")
        {

        }
    }
}
