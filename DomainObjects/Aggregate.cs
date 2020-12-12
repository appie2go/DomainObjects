namespace DomainDrivenDesign.DomainObjects
{
    /// <summary>
    /// A cluster of domain objects which define a consistency boundary. Protects transactional consistency and protects the business invariants of the domain. Uniquely identified by its id.
    /// </summary>
    /// <typeparam name="TAggregate">The type of the aggregate/The type that implements this class.</typeparam>
    /// <typeparam name="TKeyType">The type that is used to identify this aggregate.</typeparam>
    public class Aggregate<TAggregate, TKeyType> : Entity<TAggregate, TKeyType>, IEntity<TAggregate>
        where TAggregate : Entity<TAggregate, TKeyType>
        where TKeyType : Id, IId<TAggregate>
    {
        /// <summary>
        /// Creates a new instance of the Aggregate<<typeparamref name="TAggregate"/>, <typeparamref name="TKeyType"/>> class
        /// </summary>
        /// <param name="id">A unique value that identifies this object.</param>
        protected Aggregate(TKeyType id) : base(id)
        {
        }
    }

    /// <summary>
    /// A cluster of domain objects which define a consistency boundary. Protects transactional consistency and protects the business invariants of the domain. Uniquely identified by its id.
    /// </summary>
    /// <typeparam name="T">The type of the aggregate/The type that implements this class.</typeparam>
    public class Aggregate<T> : Entity<T> where T : Aggregate<T>
    {
        /// <summary>
        /// Creates a new instance of the Aggregate<<typeparamref name="T"/>> class.
        /// </summary>
        /// <param name="id">A unique value that identifies this object.</param>
        protected Aggregate(Id<T> id) : base(id)
        {
        }
    }
}
