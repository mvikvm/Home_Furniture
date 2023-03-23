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

using (IFurnitureServices furnitureService = MyLibFactory.GetFurnitureService(config))
{
	ConsoleService manager = new ConsoleService(furnitureService);
	manager.Run();
}
Console.WriteLine("Приложение закрыто.");