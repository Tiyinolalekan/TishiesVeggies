using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TishiesVeggies.Data;

namespace TishiesVeggies.Pages.LogPages;

public class DetailsModel : PageModel
{
    private readonly TishiesVeggiesDbContext _context;
    public DetailsModel(TishiesVeggiesDbContext context)
    {
        _context = context;
    }

    public Log Log { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var log = await _context.Logs.FirstOrDefaultAsync(m => m.Id == id);
        if (log is null)
        {
            return NotFound();
        }
        else
        {
            Log = log;
        }

        return Page();
    }
}
