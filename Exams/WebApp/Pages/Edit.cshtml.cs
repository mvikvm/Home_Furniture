using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLib.Interfaces;
using MyLib.Models;
using System;

namespace WebApp.Pages
{
    public class EditModel : PageModel
    {
        public int Id { get; private set; }
        public PieceOfFurniture Piece { get; private set; } = null!;

        private readonly IFurnitureServices furnitureServices;

        public EditModel(IFurnitureServices furnitureServices)
        {
            this.furnitureServices = furnitureServices ?? throw new ArgumentNullException(nameof(furnitureServices));
        }

        public IActionResult OnGet(int id)
        {
            Id = id;
            Piece = furnitureServices.GetById(id);
            return Page();
        }

        public IActionResult OnPost(PieceOfFurniture pieceOfFurniture)
        {
            furnitureServices.Update(pieceOfFurniture);
            return RedirectToPage("Index");
        }
    }
}
