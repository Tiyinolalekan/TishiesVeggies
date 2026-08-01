using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TishiesVeggies.Data
{
    public class Fruit
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Fruit/Vegetable Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Category")]
        public ItemCategory Category { get; set; }

        //public int PenceValue { get; set; } = 10;
        public bool IsQuickAdd { get; set; } = true;

        public List<Log> Logs { get; set; } = new List<Log>();
    }

    public enum  ItemCategory { Fruit, Veggie}
    
        
    
}
