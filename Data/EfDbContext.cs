using Microsoft.EntityFrameworkCore;

namespace ExercicioLinqAPI.Data.Entities
{
    public class EfDbContext : DbContext
    {
        public virtual DbSet<VendaItem> VendaItens { get; set; }

        public virtual DbSet<Venda> Vendas { get; set; }

        public virtual DbSet<Produto> Produto { get; set; }

        public EfDbContext()
        {
        }

        public EfDbContext(DbContextOptions<EfDbContext> options)
            : base(options)
        {
        }
    }
}