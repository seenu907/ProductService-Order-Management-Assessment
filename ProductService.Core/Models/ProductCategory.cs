
namespace ProductService.Core.Models;

public class ProductCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public string ParentCategoryId { get; set; }

}
