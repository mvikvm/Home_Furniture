using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLib.Interfaces;
using MyLib.Models;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<PieceOfFurniture> Items { get; private set; } = Enumerable.Empty<PieceOfFurniture>();

        private readonly IProductsService service;

        public IndexModel (IProductsService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void OnGet()
        {
            Items = service.GetAll<PieceOfFurniture>();
        }

        public IActionResult OnPostDelete(int id)
        {
            service.Delete<PieceOfFurniture>(id);
            return RedirectToPage();
        }
    }
}