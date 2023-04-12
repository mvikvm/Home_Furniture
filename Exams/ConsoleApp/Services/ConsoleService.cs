using MyLib.Interfaces;
using MyLib.Models;

namespace ConsoleApp.Services;

internal class ConsoleService
{
	private readonly IProductsService productsService;

	public ConsoleService(IProductsService productsService)
	{
		this.productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
	}

	public void Run()
	{
		bool stop = true;
		while (stop)
		{
			try
			{
				int item = Menu();
				switch (item)
				{
					case 0:
						stop = false;
						break;

					case 1:
						PieceOfFurniture pieceOfFurniture = AddNewPieceOfFurniture();
						var variable = productsService.Create(pieceOfFurniture);
						Console.WriteLine($"Предмет мебели с id   {variable.Id}, названием - {variable.Name}, в колличестве {variable.Quantity} шт.");
						Console.WriteLine("Успешно добавлен в БД.\n");
						Delay();
						break;

					case 2:
						Console.WriteLine("Введите Id предмета мебели для редактирования:");
						int id = EnteredValue();
						int idForUpdate = IsValidEnteredDijit(id);
						PieceOfFurniture pieceOfFurnitureForUpdate = AddPieceOfFurnitureForUpdate();
						pieceOfFurnitureForUpdate.Id = idForUpdate;
                        productsService.Update(pieceOfFurnitureForUpdate);
						Console.WriteLine($"Предмет мебели с id   {idForUpdate} успешно отредактирован.\n");
						Delay();
						break;

					case 3:
						Console.WriteLine("Список объектов:");
						IEnumerable<PieceOfFurniture> variables = productsService.GetAll<PieceOfFurniture>();
						Console.WriteLine("Id  |  Название  |  Колличество");
						foreach (var x in variables)
						{
							Console.WriteLine($" {x.Id}  -  {x.Name}       {x.Quantity}");
						}
						Console.WriteLine();
						Delay();
						break;

					case 4:
						Console.WriteLine("Введите Id предмета мебели для удаления:");
						int newId = EnteredValue();
						int idForDelete = IsValidEnteredDijit(newId);
                        productsService.Delete<PieceOfFurniture>(idForDelete);
						Console.WriteLine($"Предмет мебели с id   {idForDelete} успешно удален.\n");
						Delay();
						break;

					default:
						Console.WriteLine("Выберите пункт меню от 0 до 4 !\n");
						Delay();
						break;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}
	}

	/// <summary>
	/// Создание предметов мебели
	/// </summary>
	/// <returns></returns>
	private PieceOfFurniture AddNewPieceOfFurniture()
	{
		Console.Write("Введите название предмета мебели: ");
		string str = Console.ReadLine();
		string enteredString = IsValidEnteredString(str);
		Console.Write("Введите колличество: ");
		int enteredDijit = EnteredValue();
		Console.WriteLine();

		return new PieceOfFurniture(enteredString, enteredDijit);
	}

    private PieceOfFurniture AddPieceOfFurnitureForUpdate()
    {
        Console.Write("Введите название предмета мебели, если оставить прежнее нажмите Enter: ");
        string? str = Console.ReadLine();
        Console.Write("Введите колличество: ");
        int enteredDijit = EnteredValue();
        Console.WriteLine();

        return new PieceOfFurniture(str, enteredDijit);
    }

    /// <summary>
    /// Консольное меню
    /// </summary>
    /// <returns></returns>
    private int Menu()
	{
		Console.WriteLine("БАЗА ДАННЫХ ПРЕДМЕТОВ МЕБЕЛИ");
		Console.WriteLine(" 1 - Добавление нового обьекта.\n 2 - Редактирование данных.\n 3 - Вывод на экран БД.\n 4 - Удаление обьекта из БД.\n 0 - Выход из меню");
		Console.WriteLine("Выберите пункт управления БД (0-4):");
		return EnteredValue();
	}

	/// <summary>
	/// Задержка в консоли
	/// </summary>
	private void Delay()
	{
		Console.WriteLine("Для продолжения нажмите Enter\n");
		Console.ReadKey();
	}
	/// <summary>
	/// Чтение введенной цифры
	/// </summary>
	/// <returns></returns>
	private int EnteredValue()
	{
		bool x;
		int result;
		do
		{
			x = int.TryParse(Console.ReadLine(), out int data);
			result = data;
			if (x == false || result <= 0)
			{
				Console.WriteLine("Некорректный ввод, попробуйте еще раз!\n");
			}
		}
		while (x == false);
		return result;
	}

	/// <summary>
	/// Проверка id на валидность
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	private int IsValidEnteredDijit(int id)
	{
		bool x = true;
		do
		{
			if (id <= 0)
			{
				Console.WriteLine("Некорректный ввод, такого id не может существовать!");
				Console.WriteLine("Попробуйте еще раз.\n");
				id = EnteredValue();
			}
			else
			{
				x = false;
			}
		}
		while (x);
		return id;
	}

	/// <summary>
	/// Проверка строки на валидность
	/// </summary>
	/// <param name="str"></param>
	/// <returns></returns>
	private string IsValidEnteredString(string str)
	{
		bool x = true;
		do
		{
			if (string.IsNullOrWhiteSpace(str))
			{
				Console.WriteLine("Некорректное значение! Введите строку!");
				str = Console.ReadLine();
			}
			else
			{
				x = false;
			}
		}
		while (x);
		return str;

	}
}