using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain.Database;

namespace WebApp.Pages_Queries
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Guid Id { get; set; }

        public IList<Query> Query { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Query = await _context.Queries.OrderBy(q => q.Deadline).ToListAsync();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Remove(_context.Queries.First(q => q.QueryId == Id));
            
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }    }
}
