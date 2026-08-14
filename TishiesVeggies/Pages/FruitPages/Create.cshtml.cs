using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TishiesVeggies.Data;

namespace TishiesVeggies.Pages.FruitPages;

public class CreateModel : PageModel
{
    private readonly TishiesVeggiesDbContext _context;

    public CreateModel(TishiesVeggiesDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        FruitCat = Enum.GetValues<ItemCategory>()
           .Select(f => new SelectListItem
           {
               Text = f.ToString(),
               Value = f.ToString()
           })
           .ToList();

        return Page();
    }

    [BindProperty]
    public Fruit Fruit { get; set; } = default!;
    public IList<SelectListItem> FruitCat { get; set; } = [];


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
       
        _context.Fruits.Add(Fruit);
        await _context.SaveChangesAsync();

        return RedirectToPage("/LogPages/Create");
    }
}
