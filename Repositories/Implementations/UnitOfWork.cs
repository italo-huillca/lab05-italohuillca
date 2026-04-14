using System.Collections;
using Lab5_ItaloHuillca.Models;
using Lab5_ItaloHuillca.Repositories.Interfaces;

namespace Lab5_ItaloHuillca.Repositories.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private Hashtable _repositories;
    private readonly ColegioDbContext _context;

    public IMatriculaRepository Matriculas { get; }

    public UnitOfWork(ColegioDbContext context)
    {
        _context = context;
        _repositories = new Hashtable();
        Matriculas = new MatriculaRepository(context);
    }

    public Task<int> Complete()
    {
        return _context.SaveChangesAsync();
    }

    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        var type = typeof(TEntity).Name;

        if (_repositories.ContainsKey(type))
            return (IGenericRepository<TEntity>)_repositories[type]!;

        var repositoryType = typeof(GenericRepository<>);
        var repositoryInstance = Activator.CreateInstance(
            repositoryType.MakeGenericType(typeof(TEntity)), _context);

        if (repositoryInstance != null)
        {
            _repositories.Add(type, repositoryInstance);
            return (IGenericRepository<TEntity>)repositoryInstance;
        }

        throw new Exception($"Could not create repository instance for type {type}");
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}