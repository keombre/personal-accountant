using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PersonalAccountant.Data;
using PersonalAccountant.Entities;

namespace PersonalAccountant.Areas.Transactions.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly PersonalAccountant.Data.ApplicationDbContext _context;

        public DeleteModel(PersonalAccountant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TransactionEntity TransactionEntity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TransactionEntity = await _context.Transactions.FirstOrDefaultAsync(m => m.Id == id);

            if (TransactionEntity == null)
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

            TransactionEntity = await _context.Transactions.FindAsync(id);

            if (TransactionEntity != null)
            {
                _context.Transactions.Remove(TransactionEntity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
