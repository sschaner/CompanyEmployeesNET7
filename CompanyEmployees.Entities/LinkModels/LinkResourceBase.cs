namespace CompanyEmployees.Entities.LinkModels
{
    public class LinkResourceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkResourceBase"/> class.
        /// </summary>
        public LinkResourceBase()
        {

        }

        /// <summary>
        /// Gets or sets the links.
        /// </summary>
        /// <value>
        /// The links.
        /// </value>
        public List<Link> Links { get; set; } = new List<Link>();
    }
}
