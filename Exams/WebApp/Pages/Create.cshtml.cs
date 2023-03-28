using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLib.Interfaces;
using MyLib.Models;

namespace WebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IFurnitureServices furnitureServices;

        public CreateModel(IFurnitureServices furnitureServices)
        {
            this.furnitureServices = furnitureServices ?? throw new ArgumentNullException(nameof(furnitureServices));
        }

        public IActionResult OnPost (PieceOfFurniture pieceOfFurniture)
        {
            furnitureServices.Create(pieceOfFurniture);
            return RedirectToPage("Index");
        }
    }
}
