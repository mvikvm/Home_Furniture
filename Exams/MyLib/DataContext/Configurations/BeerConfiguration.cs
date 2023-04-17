using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLib.Models;

namespace MyLib.DataContext.Configurations
{
    internal class BeerConfiguration : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> builder)
        {
            builder.ToTable("Beers");
            builder.HasKey("Id");
            builder.Property(x => x.Name);
            builder.Property(x => x.TypeOfBeer);
            builder.Property(x => x.Price);
            builder.Property(x => x.Quantity);
            builder.Ignore(x => x.Order);
            builder.Ignore(x => x.OrderId);
        }
    }
}
