using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExercicioLinqAPI.Data.Entities
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.ProdutoId);
            builder.Property(b => b.ProdutoId).ValueGeneratedOnAdd();
            builder.Property(p => p.ValorUnitario).HasColumnType("decimal(18, 2)");
            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(50);
        }
    }
}