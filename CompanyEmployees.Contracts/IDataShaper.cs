namespace CompanyEmployees.Contracts
{
    using CompanyEmployees.Entities.Models;
    using System.Dynamic;

    public interface IDataShaper<T>
    {
        /// <summary>
        /// Shapes the data.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <param name="fieldsString">The fields string.</param>
        /// <returns></returns>
        IEnumerable<ShapedEntity> ShapeData(IEnumerable<T> entities, string fieldsString);

        /// <summary>
        /// Shapes the data.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="fieldsString">The fields string.</param>
        /// <returns></returns>
        ShapedEntity ShapeData(T entity, string fieldsString);
    }
}
