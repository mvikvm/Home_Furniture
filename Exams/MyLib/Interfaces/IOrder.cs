using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Interfaces
{
    public interface IOrder
    {
        public int Id { get; set; }
        public decimal TotalCost { get; set; }
        public IEnumerable<IBeer> Beers { get; set; }
    }
}
