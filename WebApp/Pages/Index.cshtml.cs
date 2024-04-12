using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class IndexModel(AppDbContext context) : PageModel
{
    private readonly AppDbContext _context = context;
    
    // Usable fields.
    public string Statistics { get; set; } = default!;

    public IActionResult OnGet()
    {
        if (_context.Queries.Any()) return Page();
        
        Statistics = "Ühtegi pöördumist veel ei ole!";
        return Page();

    }
}