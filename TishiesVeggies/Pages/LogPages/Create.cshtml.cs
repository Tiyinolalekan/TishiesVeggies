using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TishiesVeggies.Data;

namespace TishiesVeggies.Pages.LogPages;

public class CreateModel : PageModel
{
    private readonly TishiesVeggiesDbContext _context;
    public IList<Fruit> Fruits { get; set; } = new List<Fruit>();

    public CreateModel(TishiesVeggiesDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        Fruits = _context.Fruits.ToList();
        return Page();
    }

    [BindProperty]
    public Log Log { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Fruits = await _context.Fruits.ToListAsync();
            return Page();
        }

        _context.Logs.Add(Log);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
