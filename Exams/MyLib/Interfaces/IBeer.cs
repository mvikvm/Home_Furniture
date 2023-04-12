using System;
using System.Collections.Generic;
using System.Linq;
namespace MyLib.Interfaces
{
    public interface IBeer
    {

        int Id { get; set; }
        string Name { get; set; }
        public int Quantity { get; set; }
        decimal Price { get; set; }

        public int OrderId { get; set; }      // внешний ключ
        public IOrder? Order { get; set; }    // навигационное свойство
    }
}
