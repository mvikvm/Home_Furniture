using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLib.Interfaces;
using MyLib.Models;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<PieceOfFurniture> Items { get; private set; } = Enumerable.Empty<PieceOfFurniture>();
        public IEnumerable<Beer> Variables { get; private set; } = Enumerable.Empty<Beer>();

        private readonly IProductsService service;

        public IndexModel (IProductsService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void OnGet()
        {
            Variables = service.GetAll<Beer>();
            Items = service.GetAll<PieceOfFurniture>();
        }

        public IActionResult OnPostDelete(int id)
        {
            service.Delete<PieceOfFurniture>(id);
            return RedirectToPage();
        }
        public IActionResult OnPostDel(int id)
        {
            service.Delete<Beer>(id);
            return RedirectToPage();
        }
    }
}