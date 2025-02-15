using ProductService.Infrastructure;
using ProductService.Infrastructure.Data;
using ProductService.Infrastructure.UnitofWork;
using ProductService.Services;

namespace ProductServiceAPI.RegistrationExtention;

public static class RegistrationExtention
{
    public static void ServiceClassInitializer(this IServiceCollection services)
    {
        _ = services.AddTransient<IProductAction,ProductAction>();
    }

    public static void DataClassInitializer(this IServiceCollection services)
    {
        _ = services.AddDbContext<AppDbContext>();
        _ = services.AddScoped<IUnitofWork,UnitofWork>();
    }
}
