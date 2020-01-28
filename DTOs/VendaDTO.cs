using ExercicioLinqAPI.Data.Entities;

namespace ExercicioLinqAPI.DTOs
{
    public class VendaDTO : VendaItem
    {
        public decimal VendaTotal { get; set; }
    }

}