using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.DataContext.Configurations
{
    internal class PieceOfFurnitureConfiguration : IEntityTypeConfiguration<PieceOfFurniture>
    {
               public void Configure(EntityTypeBuilder<PieceOfFurniture> builder)
        {
            builder.ToTable("Piece of furniture");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Quantity);
        }
    }
}
