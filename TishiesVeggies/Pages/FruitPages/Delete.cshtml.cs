using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TishiesVeggies.Data;

namespace TishiesVeggies.Pages.FruitPages;

public class DeleteModel : PageModel
{
    private readonly TishiesVeggiesDbContext _context;

    public DeleteModel(TishiesVeggiesDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Fruit Fruit { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var fruit = await _context.Fruits.FirstOrDefaultAsync(m => m.Id == id);
        if (fruit is null)
        {
            return NotFound();
        }
        else
        {
            Fruit = fruit;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var fruit = await _context.Fruits.FindAsync(id);
        if (fruit != null)
        {
            Fruit = fruit;
            _context.Fruits.Remove(Fruit);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
