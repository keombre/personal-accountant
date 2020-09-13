using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalAccountant.Data;
using PersonalAccountant.Entities;

namespace PersonalAccountant.Areas.Transactions.Pages.Types
{
    public class EditModel : PageModel
    {
        private readonly PersonalAccountant.Data.ApplicationDbContext _context;

        public EditModel(PersonalAccountant.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TypeEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeEntityExists(TypeEntity.Id))
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

        private bool TypeEntityExists(int id)
        {
            return _context.Types.Any(e => e.Id == id);
        }
    }
}
