using MyLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Models
{
    internal class Beer : IBeer
    {
        /// <summary>
        /// Id в БД
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название пива
        /// </summary>
        public string Name { get ; set; }

        /// <summary>
        /// Стоимостьза литр
        /// </summary>
        public decimal Price { get ; set; }

        /// <summary>
        /// Колличество (Литров)
        /// </summary>
        public int Quantity{ get ; set; }

        /// <summary>
        /// Внешний ключ
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public IOrder? Order { get ; set; }

        public Beer()
        {
        }

        public Beer(string name,int quantity, decimal price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }
    }
}
