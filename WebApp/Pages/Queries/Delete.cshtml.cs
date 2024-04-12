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
    public class DeleteModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DeleteModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Query Query { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = await _context.Queries.FirstOrDefaultAsync(m => m.QueryId == id);

            if (query == null)
            {
                return NotFound();
            }
            else
            {
                Query = query;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = await _context.Queries.FindAsync(id);
            if (query != null)
            {
                Query = query;
                _context.Queries.Remove(Query);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
