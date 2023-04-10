using Microsoft.EntityFrameworkCore.Query;
using MyLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Models
{
    internal class Order : IOrder
    {
        public int Id { get ; set; }
        /// <summary>
        /// Стоимость заказа
        /// </summary>
        public decimal TotalCost { get; set; }
        public IEnumerable<IBeer> Beers { get ; set; }
        public Order()
        {
        }
        public Order( params Beer [] beer)
        {
            Beers = beer;
            foreach (var item in Beers) 
            {
                TotalCost = item.Quantity * item.Price;
            }
        }

    }
}
