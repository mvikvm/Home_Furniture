using MyLib.Interfaces;

namespace MyLib.Models
{
    internal class Order : BaseClass,IOrder
    {
        public decimal TotalCost { get; set; }
        public IEnumerable<IBeer> Beers { get ; set; }

        public Order()
        {
        }
        public Order( string name, params IBeer [] beer)
        {
            Name = name;
            Beers = beer;
            foreach (var item in Beers) 
            {
                TotalCost = item.Quantity * item.Price;
            }
        }

        public override void Update(BaseClass obj)
        {
            if (obj is IOrder item)
            {
                Name = item.Name;
                Beers = item.Beers;
                TotalCost = item.TotalCost;
            }
            else
            {
                throw new InvalidCastException($"{nameof(obj)} has invalid type.");
            }

        }
    }
}
