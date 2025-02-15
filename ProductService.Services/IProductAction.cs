using ProductService.Core.Models;
using ProductService.Core.RequestDto;


namespace ProductService.Services;

public interface IProductAction
{
    Task SaveProduct(Product request);
    Task UpdateProduct(int id, Product product);
    Task<IEnumerable<Product>> GetProducts();
}
