using ProductService.Core.Models;

namespace ProductService.Core.RequestDto;

public class ProductRequest
{
    public string name { get; set; }
    public string description { get; set; }
    public string price { get; set; }

    public Product ToModel()
    {
        return new Product
        {
            Name = name,
            Description = description,
            Price = Decimal.Parse(price)
        };
    }
}
