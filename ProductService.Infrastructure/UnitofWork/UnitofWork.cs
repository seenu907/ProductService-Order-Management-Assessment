

using Microsoft.EntityFrameworkCore;
using ProductService.Infrastructure.Data;

namespace ProductService.Infrastructure.UnitofWork;

public class UnitofWork:IUnitofWork
{
    readonly Dictionary<Type,object> _repositories = new Dictionary<Type, object>();
    AppDbContext _dbContext;
    
    public UnitofWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual IRepository<T> GetRepository<T>() where T : class
    {
        var type = typeof(T);
        if (!_repositories.ContainsKey(type))
        {
            _repositories[type] = new Repository<T>(_dbContext);
        }
        return (IRepository<T>)_repositories[type];
    }

    public void UsingTransaction(Action sqlAction)
    {
        sqlAction();
        _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}
