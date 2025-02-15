using Microsoft.AspNetCore.Mvc;
using ProductService.Core.RequestDto;
using ProductService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductServiceAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    IProductAction _productService;
    public ProductsController(IProductAction productService)
    {
        _productService = productService;
    }
    // GET: api/<ProductsController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(_productService.GetProducts());
    }

    // GET api/<ProductsController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ProductsController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductRequest productRequest)
    {

        await _productService.SaveProduct(productRequest.ToModel());
        return Ok(productRequest);
    }

    // Put api/<ProductsController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id,[FromBody] ProductRequest productRequest)
    {
        await _productService.UpdateProduct(id, productRequest.ToModel());
        return Ok(productRequest);
    }

    // DELETE api/<ProductsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
