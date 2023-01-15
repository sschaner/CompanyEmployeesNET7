namespace CompanyEmployees.Shared.RequestFeatures
{
    public abstract class RequestParameters
    {
        /// <summary>
        /// The maximum page size
        /// </summary>
        const int maxPageSize = 50;

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        /// <value>
        /// The page number.
        /// </value>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// The page size
        /// </summary>
        private int _pageSize = 10;

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        /// <summary>
        /// Gets or sets the order by.
        /// </summary>
        /// <value>
        /// The order by.
        /// </value>
        public string? OrderBy { get; set; }
    }
}
