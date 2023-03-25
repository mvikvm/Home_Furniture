using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLib.Interfaces;
using MyLib.Models;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<PieceOfFurniture> Items { get; private set; } = Enumerable.Empty<PieceOfFurniture>();

        private readonly IFurnitureServices furnitureServices;

        public IndexModel (IFurnitureServices furnitureServices)
        {
            this.furnitureServices = furnitureServices ?? throw new ArgumentNullException(nameof(furnitureServices));
        }

        public void OnGet()
        {
            Items = furnitureServices.GetAllFurniture();
        }
    }
}