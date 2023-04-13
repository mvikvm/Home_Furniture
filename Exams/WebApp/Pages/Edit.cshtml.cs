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

        private readonly IProductsService service;

        public EditModel(IProductsService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public IActionResult OnGet(int id)
        {
            Id = id;
            return Page();
        }

        public IActionResult OnPost(PieceOfFurniture pieceOfFurniture)
        {
            service.Update(pieceOfFurniture);
            return RedirectToPage("Index");
        }
    }
}
