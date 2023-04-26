using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLib.Interfaces;
using MyLib.Models;

namespace WebApp.Pages
{
    public class EditBeerModel : PageModel
    {
        public int Id { get; private set; }
        public Beer Type { get; private set; } = null!;

        private readonly IProductsService service;

        public EditBeerModel(IProductsService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public IActionResult OnGet(int id)
        {
            Id = id;
            Type = service.GetById<Beer>(id);
            return Page();
        }

        public IActionResult OnPost(Beer beer)
        {
            service.Update(beer);
            return RedirectToPage("Index");
        }
    }
}
