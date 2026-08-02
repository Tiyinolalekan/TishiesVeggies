using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TishiesVeggies.Data;
using TishiesVeggies.ViewModels;

namespace TishiesVeggies.Pages.LogPages;

public class IndexModel : PageModel
{
    private readonly TishiesVeggiesDbContext _context;

    public HistoryVM HistoryVM { get; set; } = new HistoryVM();
    public IndexModel(TishiesVeggiesDbContext context)
    {
        _context = context;
    }

    public IList<Log> Log { get; set; } = default!;
    public IList<Fruit> Fruits { get; set; } = new List<Fruit>();

    public async Task OnGetAsync()
    {
        Log = await _context.Logs.ToListAsync();
        Fruits = await _context.Fruits.ToListAsync();

        // Group logs by date and calculate total quantity and price for each date
        HistoryVM.History = Log
            .GroupBy(l => l.LoggedAt.Date)
            .Select(g => new DailyHistory
            {
                Date = g.Key,
                Quantity = g.Sum(l => l.Quantity),
                TotalPrice = g.Sum(l => l.TotalValue) / 100.0, // Convert pence to pounds
                Logs = g.ToList(),
                Fruits = Fruits.Where(f => g.Any(l => l.FruitId == f.Id)).ToList()
            })
            .OrderByDescending(dh => dh.Date)
            .ToList();
    }
}
