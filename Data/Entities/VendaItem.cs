namespace ExercicioLinqAPI.Data.Entities
{
    public class VendaItem
    {
        public long VendaItemId { get; set; }
        public long VendaId { get; set; }
        public long ProdutoId { get; set; }
        public decimal Quantidade { get; set; }

        public decimal Desconto { get; set; }

        public Produto Produto { get; set; }

    }
}