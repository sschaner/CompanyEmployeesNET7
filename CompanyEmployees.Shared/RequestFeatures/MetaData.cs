namespace CompanyEmployees.Shared.RequestFeatures
{
    public class MetaData
    {
        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>
        /// The current page.
        /// </value>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the total pages.
        /// </summary>
        /// <value>
        /// The total pages.
        /// </value>
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>
        /// The total count.
        /// </value>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has previous.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has previous; otherwise, <c>false</c>.
        /// </value>
        public bool HasPrevious => CurrentPage > 1;

        /// <summary>
        /// Gets a value indicating whether this instance has next.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has next; otherwise, <c>false</c>.
        /// </value>
        public bool HasNext => CurrentPage < TotalPages;
    }
}
