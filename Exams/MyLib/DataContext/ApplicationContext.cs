using Microsoft.EntityFrameworkCore;
using MyLib.Interfaces;
using MyLib.Models;
using System.Reflection;

namespace MyLib.DataContext;

internal class ApplicationContext : DbContext, IApplicationContext
{
    public DbSet<PieceOfFurniture> PieceOfFurnitures { get; set; }
    public DbSet<TEntity> Set<TEntity>() where TEntity : BaseClass
    {
        return base.Set<TEntity>();
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
