using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PersonalAccountant.Data;
using PersonalAccountant.Entities;

namespace PersonalAccountant.Areas.Transactions.Pages.Types
{
    public class DeleteModel : PageModel
    {
        private readonly PersonalAccountant.Data.ApplicationDbContext _context;

        public DeleteModel(PersonalAccountant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TypeEntity TypeEntity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TypeEntity = await _context.Types.FirstOrDefaultAsync(m => m.Id == id);

            if (TypeEntity == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TypeEntity = await _context.Types.FindAsync(id);

            if (TypeEntity != null)
            {
                _context.Types.Remove(TypeEntity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
