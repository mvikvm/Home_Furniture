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

        private readonly IProductsService productsService;

        public EditModel(IProductsService productsService)
        {
            this.productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        }

        public IActionResult OnGet(int id)
        {
            Id = id;
            return Page();
        }

        public IActionResult OnPost(PieceOfFurniture pieceOfFurniture)
        {
            productsService.Update(pieceOfFurniture);
            return RedirectToPage("Index");
        }
    }
}
