namespace MyLib.Interfaces
{
    public interface IOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalCost { get; set; }
        public IEnumerable<IBeer> Beers { get; set; }
    }
}
