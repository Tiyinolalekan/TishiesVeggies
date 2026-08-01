using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TishiesVeggies.Data;

namespace TishiesVeggies.Pages.LogPages;

public class EditModel : PageModel
{
    private readonly TishiesVeggiesDbContext _context;

    public EditModel(TishiesVeggiesDbContext context)
    {
        _context = context;
    }

    [BindProperty]
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
        Log = log;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Log).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LogExists(Log.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool LogExists(int id)
    {
        return _context.Logs.Any(e => e.Id == id);
    }
}
