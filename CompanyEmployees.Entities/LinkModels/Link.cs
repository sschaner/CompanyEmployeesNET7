namespace CompanyEmployees.Entities.LinkModels
{
    public class Link
    {
        /// <summary>
        /// Gets or sets the href.
        /// </summary>
        /// <value>
        /// The href.
        /// </value>
        public string? Href { get; set; }

        /// <summary>
        /// Gets or sets the relative.
        /// </summary>
        /// <value>
        /// The relative.
        /// </value>
        public string? Rel { get; set; }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>
        /// The method.
        /// </value>
        public string? Method { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Link"/> class.
        /// </summary>
        public Link()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Link"/> class.
        /// </summary>
        /// <param name="hrer">The hrer.</param>
        /// <param name="rel">The relative.</param>
        /// <param name="method">The method.</param>
        public Link(string hrer, string rel, string method)
        {
            Href = hrer;
            Rel = rel;
            Method = method;
        }
    }
}
