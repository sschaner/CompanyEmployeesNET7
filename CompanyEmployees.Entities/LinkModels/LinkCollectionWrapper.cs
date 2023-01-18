namespace CompanyEmployees.Entities.LinkModels
{
    public class LinkCollectionWrapper<T> : LinkResourceBase
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public List<T> Value { get; set; } = new List<T>();

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkCollectionWrapper{T}"/> class.
        /// </summary>
        public LinkCollectionWrapper()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkCollectionWrapper{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public LinkCollectionWrapper(List<T> value) => Value = value;
    }
}
