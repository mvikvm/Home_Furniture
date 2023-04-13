using MyLib.DataContext;
using MyLib.Interfaces;
using MyLib.Models;

namespace MyLib.Services;
internal class ProductsService : IProductsService
{
    private readonly IApplicationContext context;

    public ProductsService(IApplicationContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Добовление элемента в БД
    /// </summary>
    /// <param name="variable"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public T Create<T>(T variable) where T : BaseClass
    {
        T? item = context.Set<T>().FirstOrDefault(x => x.Name == variable.Name);
        if (item is not null)
        {
            throw new Exception($"Item {typeof(T).Name} with specified Name: {variable.Name} already exist.");
        }
        context.Set<T>().Add(variable);
        context.SaveChanges();
        return variable;
    }

    /// <summary>
    /// Получение содержимого из БД
    /// </summary>
    /// <returns></returns>
    public IEnumerable<T> GetAll<T>() where T : BaseClass
    {
        return context.Set<T>().ToArray();
    }

    /// <summary>
    /// Редактирование элемента в БД
    /// </summary>
    /// <param name="id"></param>
    /// <param name="variable"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public T Update<T>(T variable) where T : BaseClass
    {
        T? item = context.Set<T>().FirstOrDefault(x => x.Id == variable.Id);

        if (item is null)
        {
            throw new Exception($"Item {typeof(T).Name} with specified Id: {variable.Id} does not found.");
        }
        item.Update(variable);
        context.SaveChanges();
        return variable;
    }

    /// <summary>
    /// Удаление элемента из БД
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="Exception"></exception>
    public void Delete<T>(int id) where T : BaseClass
    {
        T? item = context.Set<T>().FirstOrDefault(x => x.Id == id);

        if (item is null)
        {
            throw new Exception($"Item {typeof(T).Name} with specified Id: {id} does not found.");
        }
        context.Set<T>().Remove(item);
        context.SaveChanges();
    }

    /// <summary>
    /// Поиск элемента в БД по Id
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public T GetById<T>(int id) where T : BaseClass
    {
        T? item = context.Set<T>().FirstOrDefault(x => x.Id == id);
        if (item is null)
        {
            throw new Exception($"Item {typeof(T).Name} with specified Id: {id} does not found.");
        }
        return item;
    }

    public void Dispose()
    {
        context.Dispose();
    }
}