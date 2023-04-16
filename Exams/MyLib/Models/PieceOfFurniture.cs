using MyLib.Interfaces;
namespace MyLib.Models;

public class PieceOfFurniture : BaseClass, IPieceOfFurniture
{
    /// <summary>
    /// Колличество предметов мебели
    /// </summary>
    public int Quantity { get; set; }

    public PieceOfFurniture()
    { }

    public PieceOfFurniture(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }

    public override void Update(BaseClass obj)
    {
        if (obj is PieceOfFurniture item)
        {
            Name = item.Name;
            Quantity = item.Quantity;
        }
        else
        {
            throw new InvalidCastException($"{nameof(obj)} has invalid type.");
        }
    }
}
