using Lab5_ItaloHuillca.Models;
using Lab5_ItaloHuillca.Repositories.Interfaces;
namespace Lab5_ItaloHuillca.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ColegioDbContext _context;

    public GenericRepository(ColegioDbContext context)
    {
        _context = context;
    }

    public virtual T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public virtual IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public virtual async Task AddAndSaveAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
    }

    public virtual void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public virtual void Delete(int id)
    {
        var entity = _context.Set<T>().Find(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}