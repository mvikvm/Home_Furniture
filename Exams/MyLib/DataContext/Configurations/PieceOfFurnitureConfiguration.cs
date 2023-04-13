using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLib.Models;

namespace MyLib.DataContext.Configurations;

internal class PieceOfFurnitureConfiguration : IEntityTypeConfiguration<PieceOfFurniture>
{
    public void Configure(EntityTypeBuilder<PieceOfFurniture> builder)
    {
        builder.ToTable("PiecesOfFurniture");
        builder.HasKey("Id");
        builder.Property(x => x.Name);
        builder.Property(x => x.Quantity);
    }
}
