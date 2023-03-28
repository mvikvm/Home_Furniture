using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLib.Interfaces;
using MyLib.Models;

namespace WebApp.Pages
{
    public class CreateModel : PageModel
    {
        public PieceOfFurniture Piece { get; private set; } = null!;

        private readonly IFurnitureServices furnitureServices;

        public CreateModel(IFurnitureServices furnitureServices)
        {
            this.furnitureServices = furnitureServices ?? throw new ArgumentNullException(nameof(furnitureServices));
        }

        public IActionResult OnPost (string name, int quantity)
        {
            var pieceOfFurniture = new PieceOfFurniture(name, quantity);
           /* Piece =*/ furnitureServices.Create(pieceOfFurniture);
            return RedirectToPage("Index");
        }
    }
}
