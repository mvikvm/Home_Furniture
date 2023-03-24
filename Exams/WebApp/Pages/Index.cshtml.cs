using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLib.Interfaces;
using MyLib.Models;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<PieceOfFurniture> Items { get; private set; } = Enumerable.Empty<PieceOfFurniture>();

        private readonly ILogger<IndexModel> logger;
        private readonly IFurnitureServices furnitureServices;

        public IndexModel(ILogger<IndexModel> logger, IFurnitureServices furnitureServices)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.furnitureServices = furnitureServices ?? throw new ArgumentNullException(nameof(furnitureServices));
        }

        public void OnGet()
        {
            logger.LogInformation("Start Get request handling...");
            Items = furnitureServices.GetAllFurniture();
            logger.LogInformation("End Get request handling...");
        }
    }
}