using MyLib.Interfaces;


namespace MyLib.Models
{
    internal class Beer : BaseClass, IBeer
    {
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

        public override void Update(BaseClass obj)
        {
            if (obj is Beer item)
            {
                Name = item.Name;
                Price = item.Price;
                Quantity= item.Quantity;
            }
            else
            {
                throw new InvalidCastException($"{nameof(obj)} has invalid type.");
            }
        }
    }
}
