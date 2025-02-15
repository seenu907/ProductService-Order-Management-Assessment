using ProductService.Core.Models;
using ProductService.Core.RequestDto;
using ProductService.Infrastructure.Data;
using ProductService.Infrastructure.UnitofWork;

namespace ProductService.Services;

public class ProductAction:IProductAction
{
    readonly IUnitofWork _iUnitofWork;
    readonly IRepository<Product> _productRepository;

    public ProductAction(IUnitofWork iUnitofWork) {
        _iUnitofWork = iUnitofWork;
        _productRepository= _iUnitofWork.GetRepository<Product>();
    }

    public async Task SaveProduct(Product product)
    {
        _iUnitofWork.UsingTransaction(async () => {
           await _productRepository.AddAsync(product);
        });
    }

    public async Task UpdateProduct(int id, Product product)
    {
        product.Id = id;
        _iUnitofWork.UsingTransaction(async () => {
           _productRepository.Update(product);
        });
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
       return await _productRepository.GetAllAsync();

    }

}
