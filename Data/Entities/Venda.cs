using System;
using System.Collections.Generic;

namespace ExercicioLinqAPI.Data.Entities
{
    public class Venda
    {
        public long VendaId { get; set; }
        public DateTime DataVenda { get; set; }

        public virtual List<VendaItem> Itens { get; set; } = new List<VendaItem>();

    }
}