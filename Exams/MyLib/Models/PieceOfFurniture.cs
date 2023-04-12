using MyLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Models;
public class PieceOfFurniture : BaseClass, IPieceOfFurniture
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
