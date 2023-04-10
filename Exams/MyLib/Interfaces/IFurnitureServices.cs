using MyLib.Models;

namespace MyLib.Interfaces;

public interface IFurnitureServices : IDisposable
{
	IEnumerable<PieceOfFurniture> GetAllFurniture();
	PieceOfFurniture Create(PieceOfFurniture variable);
	PieceOfFurniture Update(PieceOfFurniture variable);
    PieceOfFurniture GetById(int id);
    void Delete(int id);
}