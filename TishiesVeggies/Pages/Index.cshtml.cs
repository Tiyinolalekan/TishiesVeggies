using Microsoft.AspNetCore.Mvc;
using TishiesVeggies.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TishiesVeggies.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TishiesVeggies.Data.TishiesVeggiesDbContext _context;

        public IList<Fruit> Fruits { get; set; } = new List<Fruit>();

        public IndexModel(TishiesVeggies.Data.TishiesVeggiesDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Fruits = _context.Fruits.ToList();
        }
    }
}
