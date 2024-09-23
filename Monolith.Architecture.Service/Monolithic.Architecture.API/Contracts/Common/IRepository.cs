namespace Monolithic.Architecture.API.Contracts.Common
{
    public interface IRepository<T> where T : class
    {
        Task<T> Upsert(T entity);
        Task Delete(T entity);

    }
}