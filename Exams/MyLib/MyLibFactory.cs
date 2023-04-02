using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyLib.DataContext;
using MyLib.Interfaces;
using MyLib.Services;

namespace MyLib;

public static class MyLibFactory
{
	public static IFurnitureServices GetFurnitureService(IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("DefaultConnection");
		DbContextOptionsBuilder<ApplicationContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
		DbContextOptions<ApplicationContext> options = optionsBuilder.UseSqlServer(connectionString).Options;

		return new FurnitureService(new ApplicationContext(options));
	}
    public static void AddFurnitureService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IApplicationContext, ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IFurnitureServices, FurnitureService>();
    }
}
