namespace Lab5_ItaloHuillca.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IMatriculaRepository Matriculas { get; }
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
    Task<int> Complete();
}