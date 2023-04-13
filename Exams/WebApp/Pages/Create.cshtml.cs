using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLib.Interfaces;
using MyLib.Models;

namespace WebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IProductsService service;

        public CreateModel(IProductsService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public IActionResult OnPost (PieceOfFurniture pieceOfFurniture)
        {
            service.Create(pieceOfFurniture);
            return RedirectToPage("Index");
        }
    }
}
