using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TishiesVeggies.Data;

namespace TishiesVeggies.Pages.FruitPages;

public class DetailsModel : PageModel
{
    private readonly TishiesVeggiesDbContext _context;
    public DetailsModel(TishiesVeggiesDbContext context)
    {
        _context = context;
    }

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
}
