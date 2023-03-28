using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Models;
public class PieceOfFurniture
{
    /// <summary>
    /// id в БД
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название предмета мебели
    /// </summary>
    public string Name { get; set; }

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
}
