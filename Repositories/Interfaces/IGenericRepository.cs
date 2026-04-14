namespace Lab5_ItaloHuillca.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    Task AddAndSaveAsync(T entity);
    void Update(T entity);
    void Delete(int id);
}