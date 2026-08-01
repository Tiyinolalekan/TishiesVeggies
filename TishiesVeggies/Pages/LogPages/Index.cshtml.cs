using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TishiesVeggies.Data;

namespace TishiesVeggies.Pages.LogPages;

public class IndexModel : PageModel
{
    private readonly TishiesVeggiesDbContext _context;

    public IndexModel(TishiesVeggiesDbContext context)
    {
        _context = context;
    }

    public IList<Log> Log { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Log = await _context.Logs.ToListAsync();
    }
}
