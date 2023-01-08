namespace CompanyEmployees.Entities.Exceptions
{
    public class EmployeeNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeNotFoundException"/> class.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        public EmployeeNotFoundException(Guid employeeId)
            : base($"The employee with id: {employeeId} does not exist in the database.")
        {

        }
    }
}
