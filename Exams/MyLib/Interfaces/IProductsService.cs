using MyLib.Models;

namespace MyLib.Interfaces;

public interface IProductsService : IDisposable
{
	IEnumerable<T> GetAll<T>() where T : BaseClass;
	T Create<T>(T variable) where T : BaseClass;
	T Update<T>(T variable) where T : BaseClass;
	void Delete<T> (int id) where T : BaseClass;
    T GetById<T> (int id)where T : BaseClass;
}