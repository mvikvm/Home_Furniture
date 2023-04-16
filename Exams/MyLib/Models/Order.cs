using MyLib.Interfaces;

namespace MyLib.Models
{
    public class Order : BaseClass/*, IOrder*/
    {
        public decimal TotalCost => CountTotalCost();
        public IEnumerable<Beer> Beers { get ; set; }

        public Order()
        {
        }
        public Order( string name, params Beer [] beer)
        {
            Name = name;
            Beers = beer;
        }

        private decimal CountTotalCost()
        {
            decimal result = 0;
            foreach (var item in Beers) 
            {
                decimal cost = item.Quantity * item.Price;
                result += cost;
            }
            return result;
        }

        public override void Update(BaseClass obj)
        {
            if (obj is Order item)
            {
                Name = item.Name;
                Beers = item.Beers;
                //TotalCost = item.TotalCost;
            }
            else
            {
                throw new InvalidCastException($"{nameof(obj)} has invalid type.");
            }

        }
    }
}
