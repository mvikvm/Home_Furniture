using Microsoft.EntityFrameworkCore;
using MyLib.Models;

namespace MyLib.DataContext;

internal class ApplicationContext : DbContext
{
	public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
	{
		Database.EnsureCreated();
	}
	public DbSet<PieceOfFurniture> PieceOfFurnitures { get; set; }
}
