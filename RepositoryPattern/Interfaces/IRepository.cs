using RepositoryPattern.Domain;

namespace RepositoryPattern.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T? GetById(int id);
        IList<T> GetAll();
        T Add(T entity);
        int? Update(T entity);
        void Delete(int id);
    }
}
