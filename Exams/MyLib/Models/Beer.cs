using MyLib.Interfaces;


namespace MyLib.Models
{
    public class Beer : BaseClass/*, IBeer*/
    {
        /// <summary>
        /// Сорт пива
        /// </summary>
        public string TypeOfBeer { get; set; }
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
        public Order? Order { get ; set; }

        public Beer()
        {
        }

        public Beer(string name, string typeOfBeer,int quantity, decimal price)
        {
            Name = name;
            TypeOfBeer = typeOfBeer;
            Price = price;
            Quantity = quantity;
        }

        public override void Update(BaseClass obj)
        {
            if (obj is Beer item)
            {
                Name = item.Name;
                TypeOfBeer = item.TypeOfBeer;
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
