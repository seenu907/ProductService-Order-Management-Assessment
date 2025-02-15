
using ProductService.Infrastructure.Data;

namespace ProductService.Infrastructure.UnitofWork;

public interface IUnitofWork : IDisposable
{
    IRepository<T> GetRepository<T>() where T : class;
    void UsingTransaction(Action sqlAction);
}
