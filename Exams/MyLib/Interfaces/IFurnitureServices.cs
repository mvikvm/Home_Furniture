using MyLib.Models;

namespace MyLib.Interfaces;

public interface IFurnitureServices : IDisposable
{
	IEnumerable<PieceOfFurniture> GetAllFurniture();
	PieceOfFurniture Create(PieceOfFurniture variable);
	PieceOfFurniture Update(PieceOfFurniture variable);
	void Delete(int id);
}