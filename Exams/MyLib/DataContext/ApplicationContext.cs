using Microsoft.EntityFrameworkCore;
using MyLib.Interfaces;
using MyLib.Models;

namespace MyLib.DataContext;

internal class ApplicationContext : DbContext, IApplicationContext
{
    public DbSet<PieceOfFurniture> PieceOfFurnitures { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
