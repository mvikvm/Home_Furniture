using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyLib.DataContext;
using MyLib.Interfaces;
using MyLib.Services;

namespace MyLib;

public static class MyLibFactory
{
	public static IProductsService GetProductService(IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("DefaultConnection");
		DbContextOptionsBuilder<ApplicationContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
		DbContextOptions<ApplicationContext> options = optionsBuilder.UseSqlServer(connectionString).Options;

		return new ProductsService(new ApplicationContext(options));
	}
    public static void AddMyLibServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IApplicationContext, ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IProductsService, ProductsService>();
    }
}
