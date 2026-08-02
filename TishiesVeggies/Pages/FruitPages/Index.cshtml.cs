using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TishiesVeggies.Data;

namespace TishiesVeggies.Pages.FruitPages;

public class IndexModel : PageModel
{
    private readonly TishiesVeggiesDbContext _context;

    public IndexModel(TishiesVeggiesDbContext context)
    {
        _context = context;
    }

    public IList<Fruit> Fruit { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Fruit = await _context.Fruits.ToListAsync();
    }
}
