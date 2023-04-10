using MyLib.Models;

namespace MyLib.Interfaces;

public interface IFurnitureServices : IDisposable
{
	IEnumerable<PieceOfFurniture> GetAllFurniture();
	IPieceOfFurniture Create(IPieceOfFurniture variable);
	IPieceOfFurniture Update(IPieceOfFurniture variable);
	void Delete(int id);
}