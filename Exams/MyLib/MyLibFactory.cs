using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

		return new FurnitureServices(new ApplicationContext(options));
	}
}
