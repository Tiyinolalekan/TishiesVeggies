using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    //[BindProperty]
    //public string? CustomFruitName { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Fruits = await _context.Fruits.ToListAsync();
            return Page();
        }

        //if (!string.IsNullOrWhiteSpace(CustomFruitName))
        //{
        //    Log.CustomFruitName = CustomFruitName;
        //}

        //var fruit = await _context.Fruits.FirstOrDefaultAsync(f => f.Name == CustomFruitName);
        
        //if(fruit != null)
        //{
        //    Log.FruitId = fruit.Id;
        //}

        //else
        //{
        //    // If the fruit doesn't exist, create a new one
        //    var newFruit = new Fruit
        //    {
        //        Name = CustomFruitName,
        //        Category = ItemCategory.Fruit, // Assuming it's a fruit; adjust as necessary
        //        IsQuickAdd = false
        //    };
        //    _context.Fruits.Add(newFruit);
        //    await _context.SaveChangesAsync();
        //    Log.FruitId = newFruit.Id;
        //}

        _context.Logs.Add(Log);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
