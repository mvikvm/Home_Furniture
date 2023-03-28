using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLib.Interfaces;
using MyLib.Models;
using System;

namespace WebApp.Pages
{
    public class EditModel : PageModel
    {
        public PieceOfFurniture Piece { get; private set; } = null!;

        private readonly IFurnitureServices furnitureServices;

        public EditModel(IFurnitureServices furnitureServices)
        {
            this.furnitureServices = furnitureServices ?? throw new ArgumentNullException(nameof(furnitureServices));
        }

        public IActionResult OnPost(string name, int quantity)
        {
            var pieceOfFurniture = new PieceOfFurniture(name, quantity);
            pieceOfFurniture.Id = Piece.Id;
            furnitureServices.Update(pieceOfFurniture);
            return Page();
        }
    }
}
