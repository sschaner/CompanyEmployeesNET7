namespace CompanyEmployees.Service.DataShaping
{
    using CompanyEmployees.Contracts;
    using CompanyEmployees.Entities.Models;
    using System.Dynamic;
    using System.Reflection;

    public class DataShaper<T> : IDataShaper<T> where T : class
    {
        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        /// <value>
        /// The properties.
        /// </value>
        public PropertyInfo[] Properties { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataShaper{T}"/> class.
        /// </summary>
        public DataShaper()
        {
            Properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        /// <summary>
        /// Shapes the data.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <param name="fieldsString">The fields string.</param>
        /// <returns></returns>
        public IEnumerable<Entity> ShapeData(IEnumerable<T> entities, string fieldsString)
        {
             var requiredProperties = GetRequiredProperties(fieldsString);

             return FetchData(entities, requiredProperties);
        }

        /// <summary>
        /// Shapes the data.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="fieldsString">The fields string.</param>
        /// <returns></returns>
        public Entity ShapeData(T entity, string fieldsString)
        {
            var requiredProperties = GetRequiredProperties(fieldsString);

            return FetchDataForEntity(entity, requiredProperties);
        }

        private IEnumerable<PropertyInfo> GetRequiredProperties(string fieldsString)
        {
            var requiredProperties = new List<PropertyInfo>();
            if (!string.IsNullOrWhiteSpace(fieldsString))
            {
                var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var field in fields)
                {
                    var property = Properties
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));
                    if (property == null)
                        continue;
                    requiredProperties.Add(property);
                }
            }
            else
            {
                requiredProperties = Properties.ToList();
            }

            return requiredProperties;
        }

        /// <summary>
        /// Fetches the data.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <param name="requiredProperties">The required properties.</param>
        /// <returns></returns>
        private IEnumerable<Entity> FetchData(IEnumerable<T> entities, IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapedData = new List<Entity>();
            foreach (var entity in entities)
            {
                var shapedObject = FetchDataForEntity(entity, requiredProperties);
                shapedData.Add(shapedObject);
            }

            return shapedData;
        }

        /// <summary>
        /// Fetches the data for entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="requiredProperties">The required properties.</param>
        /// <returns></returns>
        private Entity FetchDataForEntity(T entity, IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapedObject = new Entity();

            foreach (var property in requiredProperties)
            {
                var objectPropertyValue = property.GetValue(entity);
                shapedObject.TryAdd(property.Name, objectPropertyValue);
            }

            return shapedObject;
        }
    }

}
