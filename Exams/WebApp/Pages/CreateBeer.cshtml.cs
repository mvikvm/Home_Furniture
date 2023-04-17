using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLib.Interfaces;
using MyLib.Models;

namespace WebApp.Pages
{
    public class CreateBeerModel : PageModel
    {
        private readonly IProductsService service;

        public CreateBeerModel(IProductsService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public IActionResult OnPost(Beer beer)
        {
            service.Create(beer);
            return RedirectToPage("Index");
        }
    }
}
