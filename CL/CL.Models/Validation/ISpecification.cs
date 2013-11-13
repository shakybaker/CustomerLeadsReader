namespace CL.Models.Validation
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T obj);
    }
}
