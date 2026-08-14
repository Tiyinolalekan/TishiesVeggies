using TishiesVeggies.Data;

namespace TishiesVeggies.ViewModels
{
    public class DailyHistory
    {
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public int LogId { get; set; }
        public List<Log> Logs { get; set; } = new List<Log>();
        public List<Fruit> Fruits { get; set; } = new List<Fruit>();

    }
}
