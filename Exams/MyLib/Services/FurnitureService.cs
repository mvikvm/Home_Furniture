using MyLib.DataContext;
using MyLib.Interfaces;
using MyLib.Models;

namespace MyLib.Services;
internal class FurnitureService : IFurnitureServices
{
    private readonly IApplicationContext context;

    public FurnitureService(IApplicationContext? context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Добовление элемента в БД
    /// </summary>
    /// <param name="variable"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public PieceOfFurniture Create(PieceOfFurniture variable)
    {
        var furniture = context.PieceOfFurnitures.FirstOrDefault(x => x.Name == variable.Name);

        if (furniture is not null)
        {
            throw new Exception($"Предмет мебели с названием - {variable.Name} уже существует.\n");
        }
        context.PieceOfFurnitures.Add(variable);
        context.SaveChanges();
        return variable;
    }

    /// <summary>
    /// Получение содержимого из БД
    /// </summary>
    /// <returns></returns>
    public IEnumerable<PieceOfFurniture> GetAllFurniture()
    {
        return context.PieceOfFurnitures.ToList();
    }

    /// <summary>
    /// Редактирование элемента в БД
    /// </summary>
    /// <param name="id"></param>
    /// <param name="variable"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public PieceOfFurniture Update(PieceOfFurniture variable)
    {
        var furniture = context.PieceOfFurnitures.FirstOrDefault(x => x.Id == variable.Id);

        if (furniture is null)
        {
            throw new Exception($"Предмет мебели с Id  {variable.Id} не существует.\n");
        }
        if (!string.IsNullOrEmpty(variable.Name))
        {
            furniture.Name = variable.Name;
        }
        furniture.Quantity = variable.Quantity;
        context.SaveChanges();


        return furniture;
    }

    /// <summary>
    /// Удаление элемента из БД
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="Exception"></exception>
    public void Delete(int id)
    {
        var furniture = context.PieceOfFurnitures.FirstOrDefault(x => x.Id == id);

        if (furniture is null)
        {
            throw new Exception($"Предмет мебели с Id  {id} не существует.\n");
        }
        context.PieceOfFurnitures.Remove(furniture);
        context.SaveChanges();
    }
    public PieceOfFurniture GetById(int id)
    {
        var item = context.PieceOfFurnitures.FirstOrDefault( x => x.Id == id);
        return item;
    }

    public void Dispose()
    {
        context.Dispose();
    }

}