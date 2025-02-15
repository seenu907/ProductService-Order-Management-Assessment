using Microsoft.EntityFrameworkCore;
using ProductService.Core.Models;

namespace ProductService.Infrastructure;
public class AppDbContext : DbContext
{
    public AppDbContext()
    { 
    
    }
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
    { 
       
    } 
    public DbSet<Product> Product { get; set; }

} 