using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TishiesVeggies.Data;

namespace TishiesVeggies.Pages.FruitPages;

public class EditModel : PageModel
{
    private readonly TishiesVeggiesDbContext _context;

    public EditModel(TishiesVeggiesDbContext context)
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
        Fruit = fruit;
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

        _context.Attach(Fruit).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FruitExists(Fruit.Id))
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

    private bool FruitExists(int id)
    {
        return _context.Fruits.Any(e => e.Id == id);
    }
}
