
namespace MyLib.Models
{
    public abstract class BaseClass
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public abstract void Update(BaseClass obj);
    }
}
