using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLib.Interfaces;
using MyLib.Models;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<PieceOfFurniture> Items { get; private set; } = Enumerable.Empty<PieceOfFurniture>();

        private readonly IProductsService productsService;

        public IndexModel (IProductsService productsService)
        {
            this.productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        }

        public void OnGet()
        {
            Items = productsService.GetAll<PieceOfFurniture>();
        }

        public IActionResult OnPostDelete(int id)
        {
            productsService.Delete<PieceOfFurniture>(id);
            return RedirectToPage();
        }
    }
}