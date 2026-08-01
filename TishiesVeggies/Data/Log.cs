using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TishiesVeggies.Data
{
    public class Log
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Date & Time")]
        public DateTime LoggedAt { get; set; } = DateTime.Now;

        public string? Notes { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage ="You can only log 5 Fruits/Vegetables")]
        public int Quantity { get; set; }
        [Range(1,5)]
        public int? Rating { get; set; }

        [Required]
        public int FruitId { get; set; }
        public Fruit? Fruit { get; set; }

        public int TotalValue => Quantity * 10; // Assuming each fruit/vegetable is worth 10 pence




    }
}
