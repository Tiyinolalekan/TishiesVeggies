using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TishiesVeggies.Data;

namespace TishiesVeggies.Pages
{
    public class DailyGoalModel : PageModel
    {
        private readonly TishiesVeggies.Data.TishiesVeggiesDbContext _context;

        public IList<Fruit> Fruits { get; set; } = new List<Fruit>();
        public DateTime CurrentDate { get; set; } = DateTime.Now;
        //public int TotalPence { get; set; }
        public int TodayCount { get; set; }
        public int DailyGoal { get; set; } = 5;
        public bool GoalMet => TodayCount >= DailyGoal;

       public DailyGoalModel(TishiesVeggies.Data.TishiesVeggiesDbContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            Fruits = await _context.Fruits.ToListAsync();
            //TotalPence = await _context.Logs.SumAsync(l => l.Quantity * 10);

            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            TodayCount = await _context.Logs
                .Where(l => l.LoggedAt >= today && l.LoggedAt < tomorrow)
                .SumAsync(l => l.Quantity);
        }
    }
}

