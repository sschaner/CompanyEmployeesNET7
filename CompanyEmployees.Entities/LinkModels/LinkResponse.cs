namespace CompanyEmployees.Entities.LinkModels
{
    using CompanyEmployees.Entities.Models;

    public class LinkResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance has links.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has links; otherwise, <c>false</c>.
        /// </value>
        public bool HasLinks { get; set; }

        /// <summary>
        /// Gets or sets the shaped entities.
        /// </summary>
        /// <value>
        /// The shaped entities.
        /// </value>
        public List<Entity> ShapedEntities { get; set; }

        /// <summary>
        /// Gets or sets the linked entities.
        /// </summary>
        /// <value>
        /// The linked entities.
        /// </value>
        public LinkCollectionWrapper<Entity> LinkedEntities { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkResponse"/> class.
        /// </summary>
        public LinkResponse()
        {
            LinkedEntities = new LinkCollectionWrapper<Entity>();
            ShapedEntities = new List<Entity>();
        }
    }
}
