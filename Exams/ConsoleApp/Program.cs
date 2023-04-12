using ConsoleApp.Services;
using Microsoft.Extensions.Configuration;
using MyLib;
using MyLib.Interfaces;

ConfigurationBuilder builder = new ConfigurationBuilder();
// установка пути к текущему каталогу
builder.SetBasePath(Directory.GetCurrentDirectory());
// получаем конфигурацию из файла appsettings.json
builder.AddJsonFile("appsettings.json");
// создаем конфигурацию
IConfigurationRoot config = builder.Build();

using (IProductsService genericService = MyLibFactory.GetProductService(config))
{
	ConsoleService service = new ConsoleService(genericService);
	service.Run();
}
Console.WriteLine("Приложение закрыто.");