using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExercicioLinqAPI.Data.Entities
{
    public class VendaItemMap : IEntityTypeConfiguration<VendaItem>
    {
        public void Configure(EntityTypeBuilder<VendaItem> builder)
        {
            builder.HasKey(p => p.VendaItemId);
            builder.Property(p => p.Quantidade).HasColumnType("decimal(18, 2)");
            builder.Property(p => p.Desconto).HasColumnType("decimal(18, 2)");
        }
    }
}