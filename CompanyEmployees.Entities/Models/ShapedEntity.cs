namespace CompanyEmployees.Entities.Models
{
    public class ShapedEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapedEntity"/> class.
        /// </summary>
        public ShapedEntity()
        {
            Entity = new Entity();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public Entity Entity { get; set; }
    }
}
